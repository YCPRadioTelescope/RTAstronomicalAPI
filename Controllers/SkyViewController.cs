using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RTAstronomicalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkyViewController : ControllerBase
    {
        private readonly ILogger<SkyViewController> _logger;
        public SkyViewController(ILogger<SkyViewController> logger)
        {
            _logger = logger;
        }

        public static SkyView GenerateImage(String key, int year, int month, int day, int hour, int minute, float longitude, float laditude, int altitude, float targetRA, float targetDec)
        {
            Console.WriteLine(year + ", " + month + ", " + day + ", " + hour);
            SkyView view = new SkyView();
            if (key.Equals(AstroAPIKey.getKey()))
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

                String filename = "skyview-" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + (int)longitude + "-" + (int)laditude + "-" + altitude + "-" + (int)targetRA + "-" + (int)targetDec + ".png";

                Image image = easel.sky;
                view.filepath = filename;
                view.view = image;
                view.bitmap_view = (Bitmap)image;
                var stream = new System.IO.MemoryStream();
                view.bitmap_view.Save(stream, ImageFormat.Bmp);
                view.bytes = stream.ToArray();
                return view;
            }
            else
            {
                view.filepath = "Secret Key Missing, image was not created.";
                return view;
            }
        }

        public SkyView Get()
        {
            SkyView view = new SkyView();
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            float longitude = -76.704564F;
            float laditude = 40.024409F;
            int altitude = 390;
            float targetRA = 0.0F;
            float targetDec = 0.0F;
            return GenerateImage((String)"no", year, month, day, hour, minute, longitude, laditude, altitude, targetRA, targetDec);
        }

        [HttpGet]
        public SkyView Get(string key, int year, int month, int day, int hour, int minute, float targetRA, float targetDec, float longitude, float latitude, int altitude)
        {
            Console.WriteLine("altitude: " + altitude);
            // float longitude = -76.704564F;
            // float laditude = 40.024409F;
            return GenerateImage((String)key, year, month, day, hour, minute, longitude, latitude, altitude, targetRA, targetDec);
        }
    }
}