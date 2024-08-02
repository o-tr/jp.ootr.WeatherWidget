using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    public class Icon: Logic
    {
        [SerializeField] private Sprite c100;
        [SerializeField] private Sprite c101;
        [SerializeField] private Sprite c102;
        [SerializeField] private Sprite c104;
        [SerializeField] private Sprite c110;
        [SerializeField] private Sprite c112;
        [SerializeField] private Sprite c115;
        [SerializeField] private Sprite c200;
        [SerializeField] private Sprite c201;
        [SerializeField] private Sprite c202;
        [SerializeField] private Sprite c204;
        [SerializeField] private Sprite c210;
        [SerializeField] private Sprite c212;
        [SerializeField] private Sprite c215;
        [SerializeField] private Sprite c300;
        [SerializeField] private Sprite c301;
        [SerializeField] private Sprite c302;
        [SerializeField] private Sprite c303;
        [SerializeField] private Sprite c308;
        [SerializeField] private Sprite c311;
        [SerializeField] private Sprite c313;
        [SerializeField] private Sprite c314;
        [SerializeField] private Sprite c400;
        [SerializeField] private Sprite c401;
        [SerializeField] private Sprite c402;
        [SerializeField] private Sprite c403;
        [SerializeField] private Sprite c406;
        [SerializeField] private Sprite c411;
        [SerializeField] private Sprite c413;
        [SerializeField] private Sprite c414;
        [SerializeField] private Sprite c500;
        [SerializeField] private Sprite c501;
        [SerializeField] private Sprite c502;
        [SerializeField] private Sprite c504;
        [SerializeField] private Sprite c510;
        [SerializeField] private Sprite c512;
        [SerializeField] private Sprite c515;
        [SerializeField] private Sprite c601;
        [SerializeField] private Sprite c610;
        [SerializeField] private Sprite c701;
        [SerializeField] private Sprite c711;
        [SerializeField] private Sprite c801;
        [SerializeField] private Sprite c811;

        protected Sprite GetIconByName(string iconName)
        {
            switch (iconName)
            {
                case "100":
                    return c100;
                case "101":
                    return c101;
                case "102":
                    return c102;
                case "104":
                    return c104;
                case "110":
                    return c110;
                case "112":
                    return c112;
                case "115":
                    return c115;
                case "200":
                    return c200;
                case "201":
                    return c201;
                case "202":
                    return c202;
                case "204":
                    return c204;
                case "210":
                    return c210;
                case "212":
                    return c212;
                case "215":
                    return c215;
                case "300":
                    return c300;
                case "301":
                    return c301;
                case "302":
                    return c302;
                case "303":
                    return c303;
                case "308":
                    return c308;
                case "311":
                    return c311;
                case "313":
                    return c313;
                case "314":
                    return c314;
                case "400":
                    return c400;
                case "401":
                    return c401;
                case "402":
                    return c402;
                case "403":
                    return c403;
                case "406":
                    return c406;
                case "411":
                    return c411;
                case "413":
                    return c413;
                case "414":
                    return c414;
                case "500":
                    return c500;
                case "501":
                    return c501;
                case "502":
                    return c502;
                case "504":
                    return c504;
                case "510":
                    return c510;
                case "512":
                    return c512;
                case "515":
                    return c515;
                case "601":
                    return c601;
                case "610":
                    return c610;
                case "701":
                    return c701;
                case "711":
                    return c711;
                case "801":
                    return c801;
                case "811":
                    return c811;
                default:
                    return c100;
            }
        }
        
    }
}