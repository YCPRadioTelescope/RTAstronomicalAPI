using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RTAstronomicalAPI.Controllers
{
    public class SkyView
    {
        public Image view { get; set; }
        public Bitmap bitmap_view { get; set; }
        public byte[] bytes { get; set; }
         public String filepath { get; set; }
    }
}
