using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawSky;
using Microsoft.AspNetCore.Mvc;

namespace RTAstronomicalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorizonCheckController : ControllerBase
    {
        public static Easel GenerateImage(int year, int month, int day, int hour, int minute, float longitude, float laditude, int altitude, float targetRA, float targetDec)
        {
            int WIDTH = 720;
            int HEIGHT = 180;
            DrawSky.Easel easel = new DrawSky.Easel(new System.Drawing.Size(WIDTH, HEIGHT));
            easel.dt = new DateTime(year, month, day, hour, minute, 0);
            easel.longitude = longitude;
            easel.latitude = laditude;
            easel.altitude = altitude;
            easel.targetRA = targetRA;
            easel.targetDec = targetDec;
            easel.coordinates = false;
            easel.MakeNewEasel();
            return easel;
        }

        [HttpGet]
        public HorizonCheck Get(String key, int year, int month, int day, int hour, int minute, float targetRA, float targetDec)
        {
            if(key != null && key.Equals(AstroAPIKey.getKey())) { 
                // altitude of the telescope is at 390 feet above sea level, find this in the configs
                DrawSky.Easel easel = GenerateImage(year, month, day, hour, minute, -76.704564F, 40.024409F, 390, targetRA, targetDec);
                HorizonCheck HC = new HorizonCheck();
                HC.azimuth = easel.azimuth;
                HC.elevation = easel.elevation;
                HC.visible = easel.elevation > 0; 
                return HC;
            } 
            else
            {
                HorizonCheck HC = new HorizonCheck();
                HC.azimuth = 0;
                HC.elevation = 0;
                HC.visible = false;
                return HC;
            }
        }

        [HttpPost]
        public HorizonCheck Post(int a, int b)
        {
            HorizonCheck HC = new HorizonCheck();
            HC.azimuth = a;
            HC.elevation = b;
            return HC;
        }
    }
}