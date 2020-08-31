using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AASharp;
using System.Diagnostics;

namespace DrawSky
{
    public class Easel
    {
        private Size size;
        public Bitmap sky { get; set; }
        public DateTime dt { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int altitude { get; set; }

        public bool coordinates { get; set; }

        public float targetRA { get; set; }
        public float targetDec { get; set; }

        private Font font = new Font("Courier", 10.0f);

        public Dictionary<Point, Star> starsInSky = new Dictionary<Point, Star>();

        private int GetX(double dx)
        {
            int x = 0;

            if (dx < 0.0)
            {
                x = -1;
            }
            else if (dx < 180.0)
            {
                x = (Convert.ToInt32(dx) * 2) + 360;
            }
            else
            {
                x = (Convert.ToInt32(dx) - 180) * 2;
            }

            return x;
        }

        private int GetY(double dy)
        {
            int y = -100;

            if (dy > 0)
            {
                y = (90 - Convert.ToInt32(dy)) * 2;
            }

            return y;
        }

        public Easel (Size sz)
        {
            size = sz;
            sky = new Bitmap(sz.Width, sz.Height);
        }
        public void MakeNewEasel ()
        {
            Graphics skyGraphics = Graphics.FromImage(sky);
            skyGraphics.Clear(Color.Black);
            Pen violetPen = new Pen(Brushes.Violet, 2.0f);
            Point topCenter = new Point(sky.Size.Width / 2, sky.Size.Height);
            Point bottomCenter = new Point(sky.Size.Width / 2, 0);
            //skyGraphics.DrawLine(violetPen, topCenter, bottomCenter);
            //verifyTest();
            AddCoordinates(skyGraphics);
            AddPlanets(skyGraphics);

            AddStars(skyGraphics);
            AddSun(skyGraphics);
            AddMoon(skyGraphics);

            // Add the earth features
            AddEarthFeatures(skyGraphics);

            AddTarget(skyGraphics);
        }

        public void verifyTest()
        {
            bool bHighPrecision = false;
            //Calculate the topocentric horizontal position of the Sun for Palomar Observatory on midnight UTC for the 21st of September 2007
            AASDate dateSunCalc = new AASDate(2007, 9, 21, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun, bHighPrecision);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun, bHighPrecision);
            double Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            double Height = 1706;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);

            //The result above should be that we have a setting Sun at 21 degrees above the horizon at azimuth 14 degrees south of the westerly horizon  


            //Calculate the topocentric horizontal position of the Moon for Palomar Observatory on midnight UTC for the 21st of September 2007
            AASDate dateMoonCalc = new AASDate(2007, 9, 21, true);
            double JDMoon = dateMoonCalc.Julian + AASDynamicalTime.DeltaT(dateMoonCalc.Julian) / 86400.0;
            double MoonLong = AASMoon.EclipticLongitude(JDMoon);
            double MoonLat = AASMoon.EclipticLatitude(JDMoon);
            Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat, AASNutation.TrueObliquityOfEcliptic(JDMoon));
            double MoonRad = AASMoon.RadiusVector(JDMoon);
            MoonRad /= 149597870.691; //Convert KM to AU
            Longitude = AASCoordinateTransformation.DMSToDegrees(116, 51, 45); //West is considered positive
            Latitude = AASCoordinateTransformation.DMSToDegrees(33, 21, 22);
            Height = 1706;
            AAS2DCoordinate MoonTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, Longitude, Latitude, Height, JDMoon);
            AST = AASSidereal.ApparentGreenwichSiderealTime(dateMoonCalc.Julian);
            LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
            AAS2DCoordinate MoonHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, Latitude);
            MoonHorizontal.Y += AASRefraction.RefractionFromTrue(MoonHorizontal.Y, 1013, 10);

            //The result above should be that we have a rising Moon at 17 degrees above the horizon at azimuth 38 degrees east of the southern horizon  
        }

        public void AddSun(Graphics sky)
        {
            var bHighPrecision = false;
            AASDate dateSunCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT(dateSunCalc.Julian) / 86400.0;
            double SunLong = AASSun.ApparentEclipticLongitude(JDSun, bHighPrecision);
            double SunLat = AASSun.ApparentEclipticLatitude(JDSun, bHighPrecision);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic(JDSun));
            double SunRad = AASEarth.RadiusVector(JDSun, bHighPrecision);
            double Longitude = longitude;
            double Latitude = latitude;
            double Height = altitude;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateSunCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, SunTopo.Y, Latitude);
            SunHorizontal.Y += AASRefraction.RefractionFromTrue(SunHorizontal.Y, 1013, 10);
            Debug.Print($"Sun X {SunHorizontal.X} and Y {SunHorizontal.Y}");
            sky.DrawEllipse(new Pen(Brushes.Yellow, 8.0f), new Rectangle(new Point(GetX(SunHorizontal.X), GetY(SunHorizontal.Y)), new Size(8, 8)));
        }

        public void AddMoon(Graphics sky)
        {
            AASDate dateMoonCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
            var bHighPrecision = false;
            double JDMoon = dateMoonCalc.Julian + AASDynamicalTime.DeltaT(dateMoonCalc.Julian) / 86400.0;
            double MoonLong = AASMoon.EclipticLongitude(JDMoon);
            double MoonLat = AASMoon.EclipticLatitude(JDMoon);
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(MoonLong, MoonLat, AASNutation.TrueObliquityOfEcliptic(JDMoon));
            double MoonRad = AASEarth.RadiusVector(JDMoon, bHighPrecision);

            AAS2DCoordinate MoonTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, longitude, latitude, altitude, JDMoon);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateMoonCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - MoonTopo.X;
            AAS2DCoordinate MoonHorizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, MoonTopo.Y, latitude);
            MoonHorizontal.Y += AASRefraction.RefractionFromTrue(MoonHorizontal.Y, 1013, 10);
            Debug.Print($"Moon X {MoonHorizontal.X} and Y {MoonHorizontal.Y}");
            sky.DrawEllipse(new Pen(Brushes.LightGray, 8.0f), new Rectangle(new Point(GetX(MoonHorizontal.X), GetY(MoonHorizontal.Y)), new Size(8, 8)));

        }

        public AAS2DCoordinate Transform(double planetLongitude, double planetLatitude, double date, AASDate aasDate, double Rad)
        {
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(planetLongitude, planetLatitude, AASNutation.TrueObliquityOfEcliptic(date));
            AAS2DCoordinate PlanetTopo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, Rad, longitude, latitude, altitude, date);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(aasDate.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double LocalHourAngle = AST - LongtitudeAsHourAngle - PlanetTopo.X;
            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, PlanetTopo.Y, latitude);
            Horizontal.Y += AASRefraction.RefractionFromTrue(Horizontal.Y, 1013, 10);

            return Horizontal;
        }

        public void AddPlanets(Graphics sky)
        {
            var bHighPrecision = true;
            AASDate dateCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
            double JDPlanet = dateCalc.Julian + AASDynamicalTime.DeltaT(dateCalc.Julian) / 86400.0;

            double PlanetLong = AASMercury.EclipticLongitude(JDPlanet, bHighPrecision);
            double PlanetLat = AASMercury.EclipticLatitude(JDPlanet, bHighPrecision);
            double radiusVector = AASMercury.RadiusVector(JDPlanet, bHighPrecision);
            AAS2DCoordinate Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Mercury X {Planet.X} and Y {Planet.Y}");
            Point pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            //if (pt.Y > 0.0)
            //{
            //    sky.DrawString("M", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            //}

            //PlanetLong = AASVenus.EclipticLongitude(JDPlanet, bHighPrecision);
            //PlanetLat = AASVenus.EclipticLatitude(JDPlanet, bHighPrecision);
            //radiusVector = AASVenus.RadiusVector(JDPlanet, bHighPrecision);
            //Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            //Debug.Print($"Venus X {Planet.X} and Y {Planet.Y}");
            //pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            //if (pt.Y > 0.0)
            //{
            //    sky.DrawString("V", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            //}

            PlanetLong = AASMars.EclipticLongitude(JDPlanet, bHighPrecision);
            PlanetLat = AASMars.EclipticLatitude(JDPlanet, bHighPrecision);
            radiusVector = AASMars.RadiusVector(JDPlanet, bHighPrecision);
            Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Mars X {Planet.X} and Y {Planet.Y}");
            pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            if (pt.Y > 0.0)
            {
                sky.DrawString("M", font, Brushes.Red, (float)pt.X, (float)pt.Y);
            }

            PlanetLong = AASJupiter.EclipticLongitude(JDPlanet, bHighPrecision);
            PlanetLat = AASJupiter.EclipticLatitude(JDPlanet, bHighPrecision);
            radiusVector = AASJupiter.RadiusVector(JDPlanet, bHighPrecision);
            Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Jupiter X {Planet.X} and Y {Planet.Y}");
            pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            if (pt.Y > 0.0)
            {
                sky.DrawString("J", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            }

            PlanetLong = AASSaturn.EclipticLongitude(JDPlanet, bHighPrecision);
            PlanetLat = AASSaturn.EclipticLatitude(JDPlanet, bHighPrecision);
            radiusVector = AASSaturn.RadiusVector(JDPlanet, bHighPrecision);
            Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Saturn X {Planet.X} and Y {Planet.Y}");
            pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            if (pt.Y > 0.0)
            {
                sky.DrawString("S", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            }

            PlanetLong = AASUranus.EclipticLongitude(JDPlanet, bHighPrecision);
            PlanetLat = AASUranus.EclipticLatitude(JDPlanet, bHighPrecision);
            radiusVector = AASUranus.RadiusVector(JDPlanet, bHighPrecision);
            Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Uranus X {Planet.X} and Y {Planet.Y}");
            pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            if (pt.Y > 0.0)
            {
                sky.DrawString("U", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            }

            PlanetLong = AASNeptune.EclipticLongitude(JDPlanet, bHighPrecision);
            PlanetLat = AASNeptune.EclipticLatitude(JDPlanet, bHighPrecision);
            radiusVector = AASNeptune.RadiusVector(JDPlanet, bHighPrecision);
            Planet = Transform(PlanetLong, PlanetLat, JDPlanet, dateCalc, radiusVector);
            Debug.Print($"Neptune X {Planet.X} and Y {Planet.Y}");
            pt = new Point(GetX(Planet.X), GetY(Planet.Y));
            if (pt.Y > 0.0)
            {
                sky.DrawString("N", font, Brushes.Violet, (float)pt.X, (float)pt.Y);
            }
        }

        private void AddStars(Graphics sky)
        {
            float minimumDec = latitude - (float) 90.0;
            AASDate dateCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double JD = dateCalc.Julian + AASDynamicalTime.DeltaT(dateCalc.Julian) / 86400.0;
            starsInSky.Clear();

            List<Point> summerTriangle = new List<Point>();
            List<Point> orion = new List<Point>();
            List<Point> ursaMajor = new List<Point>();
            List<Point> cassiopeia = new List<Point>();
            string[] starsOfSummerTriangle = { "Vega", "Deneb", "Altair" };
            string[] starsOfOrion = { "Rigel", "Betelgeuse", "Bellatrix", "Saiph", "Mintaka", "Alnitak" };
            string[] starsOfUrsaMajor = { "Alpha Ursae Majoris", "Beta Ursae Majoris", "Gamma Ursae Majoris", "Delta Ursae Majoris", "Epsilon Ursae Majoris", "Zeta Ursae Majoris" , "Eta Ursae Majoris"};
            string[] starsOfCassipeia = { "Caph", "Schedar", "Cih", "Ruchbah", "Segin" };

            BrightStars heavens = new BrightStars();
            foreach (Star star in heavens.Stars)
            {
                if (star.Dec > minimumDec)
                {
                    int ra = star.RaInDegrees();
                    double dec = star.Dec;
                    //AAS2DCoordinate StarTopo = AASParallax.Equatorial2Topocentric(ra, dec, 9999999999, longitude, latitude, altitude, JD);
                    double LocalHourAngle = AST - LongtitudeAsHourAngle - (star.RaInDegrees()/15.00);
                    AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, star.Dec, latitude);

                    if (Horizontal.Y > 0.0)
                    {
                        Point pt = new Point(GetX(Horizontal.X), GetY(Horizontal.Y));
                        if (!starsInSky.ContainsKey(pt))
                        {
                            sky.DrawEllipse(new Pen(star.GetColor()), new Rectangle(pt.X, pt.Y, star.CircleSize(), star.CircleSize()));
                            starsInSky.Add(pt, star);
                            Point pt1 = new Point(pt.X, pt.Y + 1);
                            Point pt2 = new Point(pt.X + 1, pt.Y + 1);
                            Point pt3 = new Point(pt.X + 1, pt.Y);
                            if (!starsInSky.ContainsKey(pt1))
                            {
                                starsInSky.Add(pt1, star);
                            }
                            if (!starsInSky.ContainsKey(pt2))
                            {
                                starsInSky.Add(pt2, star);
                            }
                            if (!starsInSky.ContainsKey(pt3))
                            {
                                starsInSky.Add(pt3, star);
                            }
                            if (starsOfUrsaMajor.Contains(star.Name))
                            {
                                ursaMajor.Add(pt);
                            }
                            if (starsOfCassipeia.Contains(star.Name2))
                            {
                                cassiopeia.Add(pt);
                            }

                            if (starsOfSummerTriangle.Contains(star.Name2))
                            {
                                summerTriangle.Add(pt);
                            }
                            if (starsOfOrion.Contains(star.Name2))
                            {
                                orion.Add(pt);
                            }
                        }
                    }
                }
            }

            if (summerTriangle.Count == 3)
            {
                summerTriangle.Add(summerTriangle[0]);
                sky.DrawLines(new Pen(Brushes.DarkGray, 1), summerTriangle.ToArray());
            }
            if (orion.Count == 6)
            {
                orion.Add(orion[0]);
                sky.DrawLines(new Pen(Brushes.DarkGray, 1), orion.ToArray());
            }
            if (ursaMajor.Count == 7)
            {
                sky.DrawLines(new Pen(Brushes.DarkGray, 1), ursaMajor.ToArray());
            }
            if (cassiopeia.Count == 5)
            {
                sky.DrawLines(new Pen(Brushes.DarkGray, 1), cassiopeia.ToArray());
            }
        }

        public void AddEarthFeatures(Graphics sky)
        {
            // start in north east with trees
            Point[] horizon = new Point[] 
            { new Point { X = 0, Y = 180 },
                new Point { X = 0, Y = 175 },
                new Point { X = 90, Y = 178 },
                new Point { X = 180, Y = 170 },
                new Point { X = 360, Y = 160 },
                new Point { X = 540, Y = 170 },
                new Point { X = 720, Y = 175 },
                new Point { X = 720, Y = 180 },
                new Point { X = 0, Y = 180 }
            };
            sky.FillClosedCurve(Brushes.GreenYellow, horizon);

            // Add trees
            sky.FillEllipse(Brushes.Green, 110, 150, 40, 30);
            sky.FillEllipse(Brushes.Green, 160, 140, 40, 40);
            sky.FillEllipse(Brushes.Green, 380, 150, 40, 30);
            sky.FillEllipse(Brushes.Green, 430, 160, 30, 20);
            sky.FillEllipse(Brushes.Green, 540, 170, 70, 15);
            sky.FillEllipse(Brushes.Green, 680, 160, 30, 30);

            // the building
            sky.FillRectangle(Brushes.Gray, 200, 155, 100, 45);
            string time = dt.ToLocalTime().ToShortTimeString();
            sky.DrawString(time, font, Brushes.White, 210, 165);

            sky.DrawString("N", font, Brushes.Violet, 4, 164);
            sky.DrawString("E", font, Brushes.Violet, 180, 164);
            sky.DrawString("S", font, Brushes.Violet, 360, 164);
            sky.DrawString("W", font, Brushes.Violet, 540, 164);
            sky.DrawString("N", font, Brushes.Violet, 700, 164);
        }

        public void AddTarget(Graphics sky)
        {
            AASDate dateCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
            double AST = AASSidereal.ApparentGreenwichSiderealTime(dateCalc.Julian);
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double JD = dateCalc.Julian + AASDynamicalTime.DeltaT(dateCalc.Julian) / 86400.0;
            double LocalHourAngle = AST - LongtitudeAsHourAngle - targetRA;
            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, targetDec, latitude);
            if (Horizontal.Y > 0.0)
            {
                Point pt = new Point(GetX(Horizontal.X), GetY(Horizontal.Y));
                sky.DrawEllipse(new Pen(Brushes.White), new Rectangle(pt.X - 3, pt.Y - 3, 6, 6));
                sky.DrawLine(new Pen(Brushes.White), new Point(pt.X - 3, pt.Y), new Point(pt.X + 3, pt.Y));
                sky.DrawLine(new Pen(Brushes.White), new Point(pt.X, pt.Y - 3), new Point(pt.X, pt.Y + 3));
                sky.DrawEllipse(new Pen(Brushes.Yellow), new Rectangle(pt.X - 5, pt.Y - 5, 10, 10));
            }
        }

        public void AddCoordinates(Graphics sky)
        {
            if (coordinates)
            {
                float minimumDec = latitude - (float)90.0;
                AASDate dateCalc = new AASDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, true);
                double AST = AASSidereal.ApparentGreenwichSiderealTime(dateCalc.Julian);
                double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
                double JD = dateCalc.Julian + AASDynamicalTime.DeltaT(dateCalc.Julian) / 86400.0;

                for (double ra = 0.0; ra < 24.0; ra++)
                {
                    for (int dec = -80; dec < 90; dec += 10)
                    {
                        if (dec > minimumDec)
                        {
                            double LocalHourAngle = AST - LongtitudeAsHourAngle - (ra * 15.0);
                            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, dec, latitude);
                            if (Horizontal.Y > 0.0)
                            {
                                Point pt = new Point(GetX(Horizontal.X), GetY(Horizontal.Y));
                                sky.DrawEllipse(new Pen(Brushes.White, 1.0f), new Rectangle(pt.X, pt.Y, 1, 1));
                            }
                        }
                    }
                }
            }
        }
    }
}
