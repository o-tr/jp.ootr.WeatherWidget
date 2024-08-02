using jp.ootr.common;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;


namespace jp.ootr.WeatherWidget
{
    public class Logic : BaseClass
    {
        [SerializeField] private VRCUrl weatherApiUrl;
        private void Start()
        {
            VRCStringDownloader.LoadUrl(weatherApiUrl, (IUdonEventReceiver)this);
        }
        
        public override void OnStringLoadSuccess(IVRCStringDownload result)
        {
            if (!VRCJson.TryDeserializeFromJson(result.Result, out var json))
            {
                OnWeatherLoadError(LoadError.InvalidJson);
                return;
            }
            if(json.DataDictionary.TryGetValue("status", out var status) && status != "success")
            {
                OnWeatherLoadError(LoadError.InvalidResponse);
                return;
            }
            OnWeatherLoadSuccess((WeatherData)json.DataDictionary);
        }
        
        public override void OnStringLoadError(IVRCStringDownload result)
        {
            OnWeatherLoadError(LoadError.FailedToLoad);
        }
        
        protected virtual void OnWeatherLoadSuccess(WeatherData data)
        {
        }
        protected virtual void OnWeatherLoadError(LoadError error)
        {
        }
    }
}
