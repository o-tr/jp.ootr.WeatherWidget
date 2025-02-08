using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace jp.ootr.WeatherWidget
{
    public class Logic : UIErrorModal
    {
        [SerializeField] private VRCUrl weatherApiUrl;

        private readonly int _animatorLoading = Animator.StringToHash("Loading");

        private void Start()
        {
            VRCStringDownloader.LoadUrl(weatherApiUrl, (IUdonEventReceiver)this);
            animator.SetBool(_animatorLoading, true);
        }

        public override void OnStringLoadSuccess(IVRCStringDownload result)
        {
            if (!VRCJson.TryDeserializeFromJson(result.Result, out var json))
            {
                OnWeatherLoadError(LoadError.InvalidJson);
                return;
            }

            if (json.DataDictionary.TryGetValue("status", out var status) && status != "success")
            {
                OnWeatherLoadError(LoadError.InvalidResponse);
                return;
            }

            var data = (WeatherData)json.DataDictionary;
            var autoUpdateInterval = data.GetAutoUpdateInterval();
            if (autoUpdateInterval > 0){
                SendCustomEventDelayedSeconds(nameof(Refresh), autoUpdateInterval);
            }
            OnWeatherLoadSuccess(data);
            animator.SetBool(_animatorLoading, false);
        }

        public override void OnStringLoadError(IVRCStringDownload result)
        {
            OnWeatherLoadError(LoadError.FailedToLoad);
            ShowErrorModal("読み込みに失敗しました", "Allow Untrusted URLs が有効になっているか確認してみてください。");
        }

        public override void CloseErrorModal()
        {
            base.CloseErrorModal();
            Refresh();
        }

        public virtual void Refresh()
        {
            VRCStringDownloader.LoadUrl(weatherApiUrl, (IUdonEventReceiver)this);
            animator.SetBool(_animatorLoading, true);
        }

        protected virtual void OnWeatherLoadSuccess(WeatherData data)
        {
        }

        protected virtual void OnWeatherLoadError(LoadError error)
        {
        }
    }
}
