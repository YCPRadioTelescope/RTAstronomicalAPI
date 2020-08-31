using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawSky
{
    public class BrightStars
    {
        public List<Star> Stars { get; set; }

        public BrightStars()
        {
            Stars = new List<Star>();
            // put the stars with lines at the top in order of the drawing
            Stars.Add(new Star("Alpha Ursae Majoris       ", "Dubhe             ", "11 04 ", 61.8, "orange", 1.8, 124));
            Stars.Add(new Star("Beta Ursae Majoris        ", "Merak             ", "11 02 ", 56.4, "white ", 2.34, 79));
            Stars.Add(new Star("Gamma Ursae Majoris       ", "Phecda            ", "11 54 ", 53.7, "white ", 2.41, 84));
            Stars.Add(new Star("Delta Ursae Majoris       ", "Megrez            ", "12 15 ", 57, "white ", 3.32, 81));
            Stars.Add(new Star("Epsilon Ursae Majoris     ", "Alioth            ", "12 54 ", 56, "white ", 1.77, 81));
            Stars.Add(new Star("Zeta Ursae Majoris        ", "Mizar             ", "13 24 ", 54.9, "white ", 2.23, 78));
            Stars.Add(new Star("Eta Ursae Majoris         ", "Alkaid            ", "13 48 ", 49.3, "lcyan ", 1.86, 101));
            Stars.Add(new Star("Theta Ursae Majoris       ", "Al Haud           ", "09 33 ", 51.7, "lyellow", 3.17, 44));
            Stars.Add(new Star("Psi Ursae Majoris         ", "                  ", "11 10 ", 44.5, "orange", 3, 147));
            Stars.Add(new Star("Mu Ursae Majoris          ", "Tania Australis   ", "10 22 ", 41.5, "red   ", 3.06, 250));
            Stars.Add(new Star("Iota Ursae Majoris        ", "Talita            ", "08 59 ", 48, "white ", 3.12, 48));
            Stars.Add(new Star("Omicron Ursae Majoris     ", "Muscida           ", "08 30 ", 60.7, "yellow", 3.35, 185));
            Stars.Add(new Star("Lambda Ursae Majoris      ", "Tania Borealis    ", "10 17 ", 42.9, "white ", 3.45, 135));
            Stars.Add(new Star("Nu Ursae Majoris          ", "Alula Borealis    ", "11 18 ", 33.1, "orange", 3.49, 420));

            Stars.Add(new Star("Alpha Orionis             ", "Betelgeuse        ", "05 55 ", 7.4, "red   ", 0.55, 430));
            Stars.Add(new Star("Gamma Orionis             ", "Bellatrix         ", "05 25 ", 6.3, "lcyan ", 1.64, 240));
            Stars.Add(new Star("Delta Orionis             ", "Mintaka           ", "05 32 ", -0.3, "cyan  ", 2.25, 920));
            Stars.Add(new Star("Epsilon Orionis           ", "Alnilam           ", "05 36 ", -1.2, "lcyan ", 1.69, 1300));
            Stars.Add(new Star("Beta Orionis              ", "Rigel             ", "05 15 ", -8.2, "lcyan ", 0.15, 770));
            Stars.Add(new Star("Kappa Orionis             ", "Saiph             ", "05 48 ", -9.7, "lcyan ", 2.07, 720));
            Stars.Add(new Star("Zeta Orionis              ", "Alnitak           ", "05 41 ", -1.9, "cyan  ", 1.75, 820));

            Stars.Add(new Star("Alpha Lyrae               ", "Vega              ", "18 37 ", 38.8, "white ", 0.03, 25));
            Stars.Add(new Star("Alpha Cygni               ", "Deneb             ", "20 41 ", 45.3, "white ", 1.24, 3000));
            Stars.Add(new Star("Alpha Aquilae             ", "Altair            ", "19 51 ", 8.9, "white ", 0.77, 17));

            Stars.Add(new Star("Beta Cassiopeiae          ", "Caph              ", "00 09 ", 59.2, "lyellow", 2.28, 55));
            Stars.Add(new Star("Alpha Cassiopeiae         ", "Schedar           ", "00 41 ", 56.5, "orange", 2.24, 230));
            Stars.Add(new Star("Gamma Cassiopeiae         ", "Cih               ", "00 57 ", 60.7, "lcyan ", 2.15, 610));
            Stars.Add(new Star("Delta Cassiopeiae         ", "Ruchbah           ", "01 26 ", 60.2, "white ", 2.66, 99));
            Stars.Add(new Star("Epsilon Cassiopeiae       ", "Segin             ", "01 54 ", 63.7, "lcyan ", 3.35, 440));
            Stars.Add(new Star("Eta Cassiopeiae           ", "Achird            ", "00 49 ", 57.8, "yellow", 3.46, 19));

            Stars.Add(new Star("Alpha Canis Majoris       ", "Sirius            ", "06 45 ", -16.7, "white ", -1.46, 9));
            Stars.Add(new Star("Alpha Carinae             ", "Canopus           ", "06 24 ", -52.7, "lyellow", -0.73, 310));
            Stars.Add(new Star("Alpha Centauri            ", "Rigil Kentaurus   ", "14 40 ", -60.8, "yellow", -0.29, 4));
            Stars.Add(new Star("Alpha Boötis              ", "Arcturus          ", "14 16 ", 19.2, "orange", -0.05, 37));
            Stars.Add(new Star("Alpha Aurigae             ", "Capella           ", "05 17 ", 46, "yellow", 0.07, 42));
            Stars.Add(new Star("Alpha Canis Minoris       ", "Procyon           ", "07 39 ", 5.2, "lyellow", 0.36, 11));
            Stars.Add(new Star("Alpha Eridani             ", "Achernar          ", "01 38 ", -57.2, "lcyan ", 0.45, 144));
            Stars.Add(new Star("Beta Centauri             ", "Hadar             ", "14 04 ", -60.4, "lcyan ", 0.61, 530));
            Stars.Add(new Star("Alpha Crucis              ", "Acrux             ", "12 27 ", -63.1, "lcyan ", 0.79, 320));
            Stars.Add(new Star("Alpha Tauri               ", "Aldebaran         ", "04 36 ", 16.5, "orange", 0.86, 65));
            Stars.Add(new Star("Alpha Scorpii             ", "Antares           ", "16 29 ", -26.4, "red   ", 0.95, 600));
            Stars.Add(new Star("Alpha Virginis            ", "Spica             ", "13 25 ", -11.2, "lcyan ", 0.97, 260));
            Stars.Add(new Star("Beta Geminorum            ", "Pollux            ", "07 45 ", 28, "orange", 1.14, 34));
            Stars.Add(new Star("Alpha Piscis Austrini     ", "Fomalhaut         ", "22 58 ", -29.6, "white ", 1.15, 25));
            Stars.Add(new Star("Beta Crucis               ", "Mimosa            ", "12 48 ", -59.7, "lcyan ", 1.26, 350));
            Stars.Add(new Star("Alpha Leonis              ", "Regulus           ", "10 08 ", 12, "lcyan ", 1.36, 78));
            Stars.Add(new Star("Epsilon Canis Majoris     ", "Adhara            ", "06 59 ", -29, "lcyan ", 1.5, 430));
            Stars.Add(new Star("Alpha Geminorum           ", "Castor            ", "07 35 ", 31.9, "white ", 1.58, 52));
            Stars.Add(new Star("Lambda Scorpii            ", "Shaula            ", "17 34 ", -37.1, "lcyan ", 1.62, 700));
            Stars.Add(new Star("Gamma Crucis              ", "Gacrux            ", "12 31 ", -57.1, "red   ", 1.63, 88));
            Stars.Add(new Star("Beta Tauri                ", "Elnath            ", "05 26 ", 28.6, "lcyan ", 1.66, 130));
            Stars.Add(new Star("Beta Carinae              ", "Miaplacidus       ", "09 13 ", -69.7, "white ", 1.67, 111));
            Stars.Add(new Star("Alpha Gruis               ", "Alnair            ", "22 08 ", -47, "lcyan ", 1.74, 101));
            Stars.Add(new Star("Alpha Persei              ", "Mirfak            ", "03 24 ", 49.9, "lyellow", 1.8, 590));
            Stars.Add(new Star("Gamma Velorum             ", "Regor             ", "08 10 ", -47.3, "cyan  ", 1.81, 840));
            Stars.Add(new Star("Delta Canis Majoris       ", "Wezen             ", "07 08 ", -26.4, "lyellow", 1.83, 1800));
            Stars.Add(new Star("Epsilon Sagittarii        ", "Kaus Australis    ", "18 24 ", -34.4, "lcyan ", 1.84, 145));
            Stars.Add(new Star("Theta Scorpii             ", "Sargas            ", "17 37 ", -43, "lyellow", 1.86, 270));
            Stars.Add(new Star("Epsilon Carinae           ", "Avior             ", "08 23 ", -59.5, "orange", 1.87, 630));
            Stars.Add(new Star("Beta Aurigae              ", "Menkalinan        ", "06 00 ", 44.9, "white ", 1.9, 82));
            Stars.Add(new Star("Alpha Trianguli Australis ", "Atria             ", "16 49 ", -69, "orange", 1.92, 420));
            Stars.Add(new Star("Gamma Geminorum           ", "Alhena            ", "06 38 ", 16.4, "white ", 1.93, 105));
            Stars.Add(new Star("Alpha Pavonis             ", "Peacock           ", "20 26 ", -56.7, "lcyan ", 1.93, 180));
            Stars.Add(new Star("Delta Velorum             ", "Koo She           ", "08 45 ", -54.7, "white ", 1.95, 80));
            Stars.Add(new Star("Beta Canis Majoris        ", "Mirzam            ", "06 23 ", -18, "lcyan ", 1.98, 500));
            Stars.Add(new Star("Alpha Hydrae              ", "Alphard           ", "09 28 ", -8.7, "orange", 1.98, 180));
            Stars.Add(new Star("Alpha Ursae Minoris       ", "Polaris           ", "02 32 ", 89.3, "lyellow", 1.99, 430));
            Stars.Add(new Star("Gamma Leonis              ", "Algieba           ", "10 20 ", 19.8, "orange", 2, 126));
            Stars.Add(new Star("Alpha Arietis             ", "Hamal             ", "02 07 ", 23.5, "orange", 2.01, 66));
            Stars.Add(new Star("Beta Ceti                 ", "Diphda            ", "00 44 ", -18, "orange", 2.04, 96));
            Stars.Add(new Star("Sigma Sagittarii          ", "Nunki             ", "18 55 ", -26.3, "lcyan ", 2.05, 220));
            Stars.Add(new Star("Theta Centauri            ", "Menkent           ", "14 07 ", -36.4, "orange", 2.06, 61));
            Stars.Add(new Star("Alpha Andromedae          ", "Alpheratz         ", "00 08 ", 29.1, "lcyan ", 2.07, 97));
            Stars.Add(new Star("Beta Andromedae           ", "Mirach            ", "01 10 ", 35.6, "red   ", 2.07, 200));
            Stars.Add(new Star("Beta Ursae Minoris        ", "Kochab            ", "14 51 ", 74.2, "orange", 2.07, 127));
            Stars.Add(new Star("Beta Gruis                ", "Al Dhanab         ", "22 43 ", -46.9, "red   ", 2.07, 170));
            Stars.Add(new Star("Alpha Ophiuchi            ", "Rasalhague        ", "17 35 ", 12.6, "white ", 2.08, 47));
            Stars.Add(new Star("Beta Persei               ", "Algol             ", "03 08 ", 41, "lcyan ", 2.09, 93));
            Stars.Add(new Star("Gamma Andromedae          ", "Almach            ", "02 04 ", 42.3, "orange", 2.1, 360));
            Stars.Add(new Star("Beta Leonis               ", "Denebola          ", "11 49 ", 14.6, "white ", 2.14, 36));
            Stars.Add(new Star("Gamma Centauri            ", "Muhlifain         ", "12 42 ", -49, "white ", 2.2, 130));
            Stars.Add(new Star("Zeta Puppis               ", "Naos              ", "08 04 ", -40, "cyan  ", 2.21, 1400));
            Stars.Add(new Star("Iota Carinae              ", "Aspidiske         ", "09 17 ", -59.3, "white ", 2.21, 690));
            Stars.Add(new Star("Alpha Coronae Borealis    ", "Alphecca          ", "15 35 ", 26.7, "white ", 2.22, 75));
            Stars.Add(new Star("Lambda Velorum            ", "Suhail            ", "09 08 ", -43.4, "orange", 2.23, 570));
            Stars.Add(new Star("Gamma Cygni               ", "Sadr              ", "20 22 ", 40.3, "lyellow", 2.23, 1500));
            Stars.Add(new Star("Gamma Draconis            ", "Eltanin           ", "17 57 ", 51.5, "orange", 2.24, 148));
            Stars.Add(new Star("Epsilon Centauri          ", "                  ", "13 40 ", -53.5, "lcyan ", 2.29, 380));
            Stars.Add(new Star("Delta Scorpii             ", "Dschubba          ", "16 00 ", -22.6, "lcyan ", 2.29, 400));
            Stars.Add(new Star("Epsilon Scorpii           ", "Wei               ", "16 50 ", -34.3, "orange", 2.29, 65));
            Stars.Add(new Star("Alpha Lupi                ", "Men               ", "14 42 ", -47.4, "lcyan ", 2.3, 550));
            Stars.Add(new Star("Eta Centauri              ", "                  ", "14 36 ", -42.2, "lcyan ", 2.33, 310));
            Stars.Add(new Star("Epsilon Boötis            ", "Izar              ", "14 45 ", 27.1, "orange", 2.35, 210));
            Stars.Add(new Star("Epsilon Pegasi            ", "Enif              ", "21 44 ", 9.9, "orange", 2.38, 670));
            Stars.Add(new Star("Kappa Scorpii             ", "Girtab            ", "17 42 ", -39, "lcyan ", 2.39, 460));
            Stars.Add(new Star("Alpha Phoenicis           ", "Ankaa             ", "00 26 ", -42.3, "orange", 2.4, 77));
            Stars.Add(new Star("Eta Ophiuchi              ", "Sabik             ", "17 10 ", -15.7, "white ", 2.43, 84));
            Stars.Add(new Star("Beta Pegasi               ", "Scheat            ", "23 04 ", 28.1, "red   ", 2.44, 200));
            Stars.Add(new Star("Eta Canis Majoris         ", "Aludra            ", "07 24 ", -29.3, "lcyan ", 2.45, 3000));
            Stars.Add(new Star("Alpha Cephei              ", "Alderamin         ", "21 19 ", 62.6, "white ", 2.45, 49));
            Stars.Add(new Star("Kappa Velorum             ", "Markeb            ", "09 22 ", -55, "lcyan ", 2.47, 540));
            Stars.Add(new Star("Epsilon Cygni             ", "Gienah            ", "20 46 ", 34, "orange", 2.48, 72));
            Stars.Add(new Star("Alpha Pegasi              ", "Markab            ", "23 05 ", 15.2, "lcyan ", 2.49, 140));
            Stars.Add(new Star("Alpha Ceti                ", "Menkar            ", "03 02 ", 4.1, "red   ", 2.54, 220));
            Stars.Add(new Star("Zeta Ophiuchi             ", "Han               ", "16 37 ", -10.6, "cyan  ", 2.54, 460));
            Stars.Add(new Star("Zeta Centauri             ", "Al Nair al Kent.  ", "13 56 ", -47.3, "lcyan ", 2.55, 390));
            Stars.Add(new Star("Delta Leonis              ", "Zosma             ", "11 14 ", 20.5, "white ", 2.56, 58));
            Stars.Add(new Star("Beta Scorpii              ", "Graffias          ", "16 05 ", -19.8, "lcyan ", 2.56, 530));
            Stars.Add(new Star("Alpha Leporis             ", "Arneb             ", "05 33 ", -17.8, "lyellow", 2.58, 1300));
            Stars.Add(new Star("Delta Centauri            ", "                  ", "12 08 ", -50.7, "lcyan ", 2.58, 400));
            Stars.Add(new Star("Gamma Corvi               ", "Gienah Ghurab     ", "12 16 ", -17.5, "lcyan ", 2.58, 165));
            Stars.Add(new Star("Zeta Sagittarii           ", "Ascella           ", "19 03 ", -29.9, "white ", 2.6, 89));
            Stars.Add(new Star("Beta Librae               ", "Zubeneschamali    ", "15 17 ", -9.4, "lcyan ", 2.61, 160));
            Stars.Add(new Star("Alpha Serpentis           ", "Unukalhai         ", "15 44 ", 6.4, "orange", 2.63, 73));
            Stars.Add(new Star("Beta Arietis              ", "Sheratan          ", "01 55 ", 20.8, "white ", 2.64, 60));
            Stars.Add(new Star("Alpha Librae              ", "Zubenelgenubi     ", "14 51 ", -16, "white ", 2.64, 77));
            Stars.Add(new Star("Alpha Columbae            ", "Phact             ", "05 40 ", -34.1, "lcyan ", 2.65, 270));
            Stars.Add(new Star("Theta Aurigae             ", "                  ", "06 00 ", 37.2, "white ", 2.65, 170));
            Stars.Add(new Star("Beta Corvi                ", "Kraz              ", "12 34 ", -23.4, "yellow", 2.65, 140));
            Stars.Add(new Star("Eta Boötis                ", "Muphrid           ", "13 55 ", 18.4, "yellow", 2.68, 37));
            Stars.Add(new Star("Beta Lupi                 ", "Ke Kouan          ", "14 59 ", -43.1, "lcyan ", 2.68, 520));
            Stars.Add(new Star("Iota Aurigae              ", "Hassaleh          ", "04 57 ", 33.2, "orange", 2.69, 510));
            Stars.Add(new Star("Mu Velorum                ", "                  ", "10 47 ", -49.4, "yellow", 2.69, 116));
            Stars.Add(new Star("Alpha Muscae              ", "                  ", "12 37 ", -69.1, "lcyan ", 2.69, 310));
            Stars.Add(new Star("Upsilon Scorpii           ", "Lesath            ", "17 31 ", -37.3, "lcyan ", 2.7, 520));
            Stars.Add(new Star("Pi Puppis                 ", "                  ", "07 17 ", -37.1, "orange", 2.71, 1100));
            Stars.Add(new Star("Delta Sagittarii          ", "Kaus Meridionalis ", "18 21 ", -29.8, "orange", 2.72, 310));
            Stars.Add(new Star("Gamma Aquilae             ", "Tarazed           ", "19 46 ", 10.6, "orange", 2.72, 460));
            Stars.Add(new Star("Delta Ophiuchi            ", "Yed Prior         ", "16 14 ", -3.7, "red   ", 2.73, 170));
            Stars.Add(new Star("Eta Draconis              ", "Aldhibain         ", "16 24 ", 61.5, "yellow", 2.73, 88));
            Stars.Add(new Star("Theta Carinae             ", "                  ", "10 43 ", -64.4, "lcyan ", 2.74, 440));
            Stars.Add(new Star("Gamma Virginis            ", "Porrima           ", "12 42 ", -1.5, "lyellow", 2.74, 39));
            Stars.Add(new Star("Iota Orionis              ", "Hatysa            ", "05 35 ", -5.9, "cyan  ", 2.75, 1300));
            Stars.Add(new Star("Iota Centauri             ", "                  ", "13 21 ", -36.7, "white ", 2.75, 59));
            Stars.Add(new Star("Beta Ophiuchi             ", "Cebalrai          ", "17 43 ", 4.6, "orange", 2.76, 82));
            Stars.Add(new Star("Beta Eridani              ", "Kursa             ", "05 08 ", -5.1, "white ", 2.78, 89));
            Stars.Add(new Star("Beta Herculis             ", "Kornephoros       ", "16 30 ", 21.5, "yellow", 2.78, 150));
            Stars.Add(new Star("Delta Crucis              ", "                  ", "12 15 ", -58.7, "lcyan ", 2.79, 360));
            Stars.Add(new Star("Beta Draconis             ", "Rastaban          ", "17 30 ", 52.3, "yellow", 2.79, 360));
            Stars.Add(new Star("Alpha Canum Venaticorum   ", "Cor Caroli        ", "12 56 ", 38.3, "white ", 2.8, 110));
            Stars.Add(new Star("Gamma Lupi                ", "                  ", "15 35 ", -41.2, "lcyan ", 2.8, 570));
            Stars.Add(new Star("Beta Leporis              ", "Nihal             ", "05 28 ", -20.8, "yellow", 2.81, 160));
            Stars.Add(new Star("Zeta Herculis             ", "Rutilicus         ", "16 41 ", 31.6, "lyellow", 2.81, 35));
            Stars.Add(new Star("Beta Hydri                ", "                  ", "00 26 ", -77.3, "yellow", 2.82, 24));
            Stars.Add(new Star("Tau Scorpii               ", "                  ", "16 36 ", -28.2, "lcyan ", 2.82, 430));
            Stars.Add(new Star("Lambda Sagittarii         ", "Kaus Borealis     ", "18 28 ", -25.4, "orange", 2.82, 77));
            Stars.Add(new Star("Gamma Pegasi              ", "Algenib           ", "00 13 ", 15.2, "lcyan ", 2.83, 330));
            Stars.Add(new Star("Rho Puppis                ", "Turais            ", "08 08 ", -24.3, "lyellow", 2.83, 63));
            Stars.Add(new Star("Beta Trianguli Australis  ", "                  ", "15 55 ", -63.4, "lyellow", 2.83, 40));
            Stars.Add(new Star("Zeta Persei               ", "                  ", "03 54 ", 31.9, "lcyan ", 2.84, 980));
            Stars.Add(new Star("Beta Arae                 ", "                  ", "17 25 ", -55.5, "orange", 2.84, 600));
            Stars.Add(new Star("Alpha Arae                ", "Choo              ", "17 32 ", -49.9, "lcyan ", 2.84, 240));
            Stars.Add(new Star("Eta Tauri                 ", "Alcyone           ", "03 47 ", 24.1, "lcyan ", 2.85, 370));
            Stars.Add(new Star("Epsilon Virginis          ", "Vindemiatrix      ", "13 02 ", 11, "yellow", 2.85, 102));
            Stars.Add(new Star("Delta Capricorni          ", "Deneb Algedi      ", "21 47 ", -16.1, "white ", 2.85, 39));
            Stars.Add(new Star("Alpha Hydri               ", "Head of Hydrus    ", "01 59 ", -61.6, "lyellow", 2.86, 71));
            Stars.Add(new Star("Delta Cygni               ", "                  ", "19 45 ", 45.1, "lcyan ", 2.86, 170));
            Stars.Add(new Star("Mu Geminorum              ", "Tejat             ", "06 23 ", 22.5, "red   ", 2.87, 230));
            Stars.Add(new Star("Gamma Trianguli Australis ", "                  ", "15 19 ", -68.7, "white ", 2.87, 180));
            Stars.Add(new Star("Alpha Tucanae             ", "                  ", "22 19 ", -60.3, "orange", 2.87, 200));
            Stars.Add(new Star("Theta Eridani             ", "Acamar            ", "02 58 ", -40.3, "white ", 2.88, 160));
            Stars.Add(new Star("Pi Sagittarii             ", "Albaldah          ", "19 10 ", -21, "lyellow", 2.88, 440));
            Stars.Add(new Star("Beta Canis Minoris        ", "Gomeisa           ", "07 27 ", 8.3, "lcyan ", 2.89, 170));
            Stars.Add(new Star("Pi Scorpii                ", "                  ", "15 59 ", -26.1, "lcyan ", 2.89, 460));
            Stars.Add(new Star("Epsilon Persei            ", "                  ", "03 58 ", 40, "lcyan ", 2.9, 540));
            Stars.Add(new Star("Sigma Scorpii             ", "Alniyat           ", "16 21 ", -25.6, "lcyan ", 2.9, 730));
            Stars.Add(new Star("Beta Cygni                ", "Albireo           ", "19 31 ", 28, "orange", 2.9, 390));
            Stars.Add(new Star("Beta Aquarii              ", "Sadalsuud         ", "21 32 ", -5.6, "yellow", 2.9, 610));
            Stars.Add(new Star("Gamma Persei              ", "                  ", "03 05 ", 53.5, "yellow", 2.91, 260));
            Stars.Add(new Star("Upsilon Carinae           ", "                  ", "09 47 ", -65.1, "white ", 2.92, 1600));
            Stars.Add(new Star("Eta Pegasi                ", "Matar             ", "22 43 ", 30.2, "yellow", 2.93, 215));
            Stars.Add(new Star("Tau Puppis                ", "                  ", "06 50 ", -50.6, "orange", 2.94, 185));
            Stars.Add(new Star("Delta Corvi               ", "Algorel           ", "12 30 ", -16.5, "lcyan ", 2.94, 88));
            Stars.Add(new Star("Alpha Aquarii             ", "Sadalmelik        ", "22 06 ", -0.3, "yellow", 2.95, 760));
            Stars.Add(new Star("Gamma Eridani             ", "Zaurak            ", "03 58 ", -13.5, "red   ", 2.97, 220));
            Stars.Add(new Star("Zeta Tauri                ", "Alheka            ", "05 38 ", 21.1, "lcyan ", 2.97, 420));
            Stars.Add(new Star("Epsilon Leonis            ", "Ras Elased Austr. ", "09 46 ", 23.8, "yellow", 2.97, 250));
            Stars.Add(new Star("Gamma² Sagittarii         ", "Alnasl            ", "18 06 ", -30.4, "orange", 2.98, 96));
            Stars.Add(new Star("Gamma Hydrae              ", "                  ", "13 19 ", -23.2, "yellow", 2.99, 132));
            Stars.Add(new Star("Iota¹ Scorpii             ", "                  ", "17 48 ", -40.1, "lyellow", 2.99, 1800));
            Stars.Add(new Star("Zeta Aquilae              ", "Deneb el Okab     ", "19 05 ", 13.9, "white ", 2.99, 83));
            Stars.Add(new Star("Beta Trianguli            ", "                  ", "02 10 ", 35, "white ", 3, 124));
            Stars.Add(new Star("Gamma Ursae Minoris       ", "Pherkad Major     ", "15 21 ", 71.8, "white ", 3, 480));
            Stars.Add(new Star("Mu¹ Scorpii               ", "                  ", "16 52 ", -38, "lcyan ", 3, 820));
            Stars.Add(new Star("Gamma Gruis               ", "                  ", "21 54 ", -37.4, "lcyan ", 3, 205));
            Stars.Add(new Star("Delta Persei              ", "                  ", "03 43 ", 47.8, "lcyan ", 3.01, 530));
            Stars.Add(new Star("Zeta Canis Majoris        ", "Phurad            ", "06 20 ", -30.1, "lcyan ", 3.02, 340));
            Stars.Add(new Star("Omicron² Canis Majoris    ", "                  ", "07 03 ", -23.8, "lcyan ", 3.02, 2600));
            Stars.Add(new Star("Epsilon Corvi             ", "Minkar            ", "12 10 ", -22.6, "orange", 3.02, 300));
            Stars.Add(new Star("Epsilon Aurigae           ", "Almaaz            ", "05 02 ", 43.8, "lyellow", 3.03, 2000));
            Stars.Add(new Star("Beta Muscae               ", "                  ", "12 46 ", -68.1, "lcyan ", 3.04, 310));
            Stars.Add(new Star("Gamma Boötis              ", "Seginus           ", "14 32 ", 38.3, "white ", 3.04, 85));
            Stars.Add(new Star("Beta Capricorni           ", "Dabih             ", "20 21 ", -14.8, "yellow", 3.05, 340));
            Stars.Add(new Star("Epsilon Geminorum         ", "Mebsuta           ", "06 44 ", 25.1, "yellow", 3.06, 900));
            Stars.Add(new Star("Delta Draconis            ", "Tais              ", "19 13 ", 67.7, "yellow", 3.07, 100));
            Stars.Add(new Star("Eta Sagittarii            ", "                  ", "18 18 ", -36.8, "red   ", 3.1, 149));
            Stars.Add(new Star("Zeta Hydrae               ", "                  ", "08 55 ", 5.9, "yellow", 3.11, 150));
            Stars.Add(new Star("Nu Hydrae                 ", "                  ", "10 50 ", -16.2, "orange", 3.11, 139));
            Stars.Add(new Star("Lambda Centauri           ", "                  ", "11 36 ", -63, "lcyan ", 3.11, 410));
            Stars.Add(new Star("Alpha Indi                ", "Persian           ", "20 38 ", -47.3, "orange", 3.11, 101));
            Stars.Add(new Star("Beta Columbae             ", "Wazn              ", "05 51 ", -35.8, "orange", 3.12, 86));
            Stars.Add(new Star("Zeta Arae                 ", "                  ", "16 59 ", -56, "orange", 3.12, 570));
            Stars.Add(new Star("Delta Herculis            ", "Sarin             ", "17 15 ", 24.8, "white ", 3.12, 78));
            Stars.Add(new Star("Kappa Centauri            ", "Ke Kwan           ", "14 59 ", -42.1, "lcyan ", 3.13, 540));
            Stars.Add(new Star("Alpha Lyncis              ", "                  ", "09 21 ", 34.4, "orange", 3.14, 220));
            Stars.Add(new Star("N Velorum                 ", "                  ", "09 31 ", -57, "orange", 3.16, 240));
            Stars.Add(new Star("Pi Herculis               ", "                  ", "17 15 ", 36.8, "orange", 3.16, 370));
            Stars.Add(new Star("Nu Puppis                 ", "                  ", "06 38 ", -43.2, "lcyan ", 3.17, 420));
            Stars.Add(new Star("Zeta Draconis             ", "Aldhibah          ", "17 09 ", 65.7, "lcyan ", 3.17, 340));
            Stars.Add(new Star("Phi Sagittarii            ", "                  ", "18 46 ", -27, "lcyan ", 3.17, 230));
            Stars.Add(new Star("Eta Aurigae               ", "Hoedus II         ", "05 07 ", 41.2, "lcyan ", 3.18, 220));
            Stars.Add(new Star("Alpha Circini             ", "                  ", "14 43 ", -65, "lyellow", 3.18, 53));
            Stars.Add(new Star("Pi³ Orionis               ", "Tabit             ", "04 50 ", 7, "lyellow", 3.19, 26));
            Stars.Add(new Star("Epsilon Leporis           ", "                  ", "05 05 ", -22.4, "orange", 3.19, 225));
            Stars.Add(new Star("Kappa Ophiuchi            ", "                  ", "16 58 ", 9.4, "orange", 3.19, 86));
            Stars.Add(new Star("G Scorpii                 ", "                  ", "17 50 ", -37, "orange", 3.19, 127));
            Stars.Add(new Star("Zeta Cygni                ", "                  ", "21 13 ", 30.2, "yellow", 3.21, 151));
            Stars.Add(new Star("Gamma Cephei              ", "Errai             ", "23 39 ", 77.6, "orange", 3.21, 45));
            Stars.Add(new Star("Delta Lupi                ", "                  ", "15 21 ", -40.6, "lcyan ", 3.22, 510));
            Stars.Add(new Star("Epsilon Ophiuchi          ", "Yed Posterior     ", "16 18 ", -4.7, "yellow", 3.23, 108));
            Stars.Add(new Star("Eta Serpentis             ", "Alava             ", "18 21 ", -2.9, "orange", 3.23, 62));
            Stars.Add(new Star("Beta Cephei               ", "Alphirk           ", "21 29 ", 70.6, "lcyan ", 3.23, 600));
            Stars.Add(new Star("Alpha Pictoris            ", "                  ", "06 48 ", -61.9, "white ", 3.24, 99));
            Stars.Add(new Star("Theta Aquilae             ", "                  ", "20 11 ", -0.8, "lcyan ", 3.24, 285));
            Stars.Add(new Star("Sigma Puppis              ", "                  ", "07 29 ", -43.3, "orange", 3.25, 185));
            Stars.Add(new Star("Pi Hydrae                 ", "                  ", "14 06 ", -26.7, "orange", 3.25, 101));
            Stars.Add(new Star("Sigma Librae              ", "Brachium          ", "15 04 ", -25.3, "red   ", 3.25, 290));
            Stars.Add(new Star("Gamma Lyrae               ", "Sulaphat          ", "18 59 ", 32.7, "lcyan ", 3.25, 630));
            Stars.Add(new Star("Gamma Hydri               ", "                  ", "03 47 ", -74.2, "red   ", 3.26, 215));
            Stars.Add(new Star("Delta Andromedae          ", "                  ", "00 39 ", 30.9, "orange", 3.27, 101));
            Stars.Add(new Star("Theta Ophiuchi            ", "                  ", "17 22 ", -25, "lcyan ", 3.27, 560));
            Stars.Add(new Star("Delta Aquarii             ", "Skat              ", "22 55 ", -15.8, "white ", 3.27, 160));
            Stars.Add(new Star("Mu Leporis                ", "                  ", "05 13 ", -16.2, "lcyan ", 3.29, 185));
            Stars.Add(new Star("Omega Carinae             ", "                  ", "10 14 ", -70, "lcyan ", 3.29, 370));
            Stars.Add(new Star("Iota Draconis             ", "Edasich           ", "15 25 ", 59, "orange", 3.29, 102));
            Stars.Add(new Star("Alpha Doradus             ", "                  ", "04 34 ", -55, "white ", 3.3, 175));
            Stars.Add(new Star("p Carinae                 ", "                  ", "10 32 ", -61.7, "lcyan ", 3.3, 500));
            Stars.Add(new Star("Mu Centauri               ", "                  ", "13 50 ", -42.5, "lcyan ", 3.3, 530));
            Stars.Add(new Star("Eta Geminorum             ", "Propus            ", "06 15 ", 22.5, "red   ", 3.31, 350));
            Stars.Add(new Star("Alpha Herculis            ", "Rasalgethi        ", "17 15 ", 14.4, "red   ", 3.31, 380));
            Stars.Add(new Star("Gamma Arae                ", "                  ", "17 25 ", -56.4, "lcyan ", 3.31, 1100));
            Stars.Add(new Star("Beta Phoenicis            ", "                  ", "01 06 ", -46.7, "yellow", 3.32, 190));
            Stars.Add(new Star("Rho Persei                ", "Gorgonea Tertia   ", "03 05 ", 38.8, "red   ", 3.32, 325));
            Stars.Add(new Star("Eta Scorpii               ", "                  ", "17 12 ", -43.2, "lyellow", 3.32, 72));
            Stars.Add(new Star("Nu Ophiuchi               ", "                  ", "17 59 ", -9.8, "orange", 3.32, 155));
            Stars.Add(new Star("Tau Sagittarii            ", "                  ", "19 07 ", -27.7, "orange", 3.32, 120));
            Stars.Add(new Star("Alpha Reticuli            ", "                  ", "04 14 ", -62.5, "yellow", 3.33, 165));
            Stars.Add(new Star("Theta Leonis              ", "Chort             ", "11 14 ", 15.4, "white ", 3.33, 180));
            Stars.Add(new Star("Xi Puppis                 ", "Asmidiske         ", "07 49 ", -24.9, "yellow", 3.34, 1300));
            Stars.Add(new Star("Eta Orionis               ", "Algjebbah         ", "05 24 ", -2.4, "lcyan ", 3.35, 900));
            Stars.Add(new Star("Xi Geminorum              ", "Alzirr            ", "06 45 ", 12.9, "lyellow", 3.35, 57));
            Stars.Add(new Star("Delta Aquilae             ", "                  ", "19 25 ", 3.1, "lyellow", 3.36, 50));
            Stars.Add(new Star("Epsilon Lupi              ", "                  ", "15 23 ", -44.7, "lcyan ", 3.37, 500));
            Stars.Add(new Star("Zeta Virginis             ", "Heze              ", "13 35 ", -0.6, "white ", 3.38, 73));
            Stars.Add(new Star("Epsilon Hydrae            ", "                  ", "08 47 ", 6.4, "yellow", 3.38, 135));
            Stars.Add(new Star("Lambda Orionis            ", "Meissa            ", "05 35 ", 9.9, "cyan  ", 3.39, 1100));
            Stars.Add(new Star("q Carinae                 ", "                  ", "10 17 ", -61.3, "orange", 3.39, 740));
            Stars.Add(new Star("Delta Virginis            ", "Auva              ", "12 56 ", 3.4, "red   ", 3.39, 200));
            Stars.Add(new Star("Zeta Cephei               ", "                  ", "22 11 ", 58.2, "orange", 3.39, 730));
            Stars.Add(new Star("Theta² Tauri              ", "                  ", "04 29 ", 15.9, "white ", 3.4, 150));
            Stars.Add(new Star("Gamma Phoenicis           ", "                  ", "01 28 ", -43.3, "orange", 3.41, 235));
            Stars.Add(new Star("Lambda Tauri              ", "                  ", "04 01 ", 12.5, "lcyan ", 3.41, 370));
            Stars.Add(new Star("Nu Centauri               ", "                  ", "13 50 ", -41.7, "lcyan ", 3.41, 475));
            Stars.Add(new Star("Zeta Lupi                 ", "                  ", "15 12 ", -52.1, "yellow", 3.41, 116));
            Stars.Add(new Star("Eta Cephei                ", "                  ", "20 45 ", 61.8, "orange", 3.41, 47));
            Stars.Add(new Star("Zeta Pegasi               ", "Homam             ", "22 41 ", 10.8, "lcyan ", 3.41, 210));
            Stars.Add(new Star("Alpha Trianguli           ", "Mothallah         ", "01 53 ", 29.6, "lyellow", 3.42, 64));
            Stars.Add(new Star("Eta Lupi                  ", "                  ", "16 00 ", -38.4, "lcyan ", 3.42, 495));
            Stars.Add(new Star("Mu Herculis               ", "                  ", "17 46 ", 27.7, "yellow", 3.42, 27));
            Stars.Add(new Star("Beta Pavonis              ", "                  ", "20 45 ", -66.2, "white ", 3.42, 140));
            Stars.Add(new Star("a Carinae                 ", "                  ", "09 11 ", -58.9, "lcyan ", 3.43, 420));
            Stars.Add(new Star("Zeta Leonis               ", "Adhafera          ", "10 17 ", 23.4, "lyellow", 3.43, 260));
            Stars.Add(new Star("Lambda Aquilae            ", "Althalimain       ", "19 06 ", -4.9, "lcyan ", 3.43, 125));
            Stars.Add(new Star("Beta Lyrae                ", "Sheliak           ", "18 50 ", 33.4, "lcyan ", 3.45, 880));
            Stars.Add(new Star("Eta Ceti                  ", "Dheneb            ", "01 09 ", -10.2, "orange", 3.46, 118));
            Stars.Add(new Star("Chi Carinae               ", "                  ", "07 57 ", -53, "lcyan ", 3.46, 390));
            Stars.Add(new Star("Delta Bootis              ", "                  ", "15 16 ", 33.3, "yellow", 3.46, 117));
            Stars.Add(new Star("Gamma Ceti                ", "Kaffaljidhma      ", "02 43 ", 3.2, "white ", 3.47, 82));
            Stars.Add(new Star("Eta Leonis                ", "                  ", "10 07 ", 16.8, "white ", 3.48, 2100));
            Stars.Add(new Star("Eta Herculis              ", "                  ", "16 43 ", 38.9, "yellow", 3.48, 112));
            Stars.Add(new Star("Tau Ceti                  ", "                  ", "01 44 ", -15.9, "yellow", 3.49, 12));
            Stars.Add(new Star("Sigma Canis Majoris       ", "                  ", "07 02 ", -27.9, "orange", 3.49, 1200));
            Stars.Add(new Star("Beta Bootis               ", "Nekkar            ", "15 02 ", 40.4, "yellow", 3.49, 220));
            Stars.Add(new Star("Alpha Telescopii          ", "                  ", "18 27 ", -46, "lcyan ", 3.49, 250));
            Stars.Add(new Star("Epsilon Gruis             ", "                  ", "22 49 ", -51.3, "white ", 3.49, 130));
            Stars.Add(new Star("Kappa Canis Majoris       ", "                  ", "06 50 ", -32.5, "lcyan ", 3.5, 790));
            Stars.Add(new Star("Delta Geminorum           ", "Wasat             ", "07 20 ", 22, "lyellow", 3.5, 59));
            Stars.Add(new Star("Iota Cephei               ", "                  ", "22 50 ", 66.2, "orange", 3.5, 115));
            Stars.Add(new Star("Gamma Sagittae            ", "                  ", "19 59 ", 19.5, "orange", 3.51, 270));
            Stars.Add(new Star("Mu Pegasi                 ", "Sadalbari         ", "22 50 ", 24.6, "yellow", 3.51, 117));
            Stars.Add(new Star("Delta Eridani             ", "Rana              ", "03 43 ", -9.8, "orange", 3.52, 29));
            Stars.Add(new Star("Omicron Leonis            ", "Subra             ", "09 41 ", 9.9, "white ", 3.52, 135));
            Stars.Add(new Star("Phi Velorum               ", "Tseen Ke          ", "09 57 ", -54.6, "lcyan ", 3.52, 1900));
            Stars.Add(new Star("Xi² Sagittarii            ", "                  ", "18 58 ", -21.1, "orange", 3.52, 370));
            Stars.Add(new Star("Theta Pegasi              ", "Baham             ", "22 10 ", 6.2, "white ", 3.52, 97));
            Stars.Add(new Star("Epsilon Tauri             ", "Ain               ", "04 29 ", 19.2, "orange", 3.53, 155));
            Stars.Add(new Star("Beta Cancri               ", "Tarf              ", "08 17 ", 9.2, "orange", 3.53, 290));
            Stars.Add(new Star("Xi Hydrae                 ", "                  ", "11 33 ", -31.9, "yellow", 3.54, 130));
            Stars.Add(new Star("Mu Serpentis              ", "                  ", "15 50 ", -3.4, "white ", 3.54, 155));
            Stars.Add(new Star("Xi Serpentis              ", "                  ", "17 38 ", -15.4, "lyellow", 3.54, 105));
        }
    }

    public class Star
    {
        public Star(string name, string name2, string ra, double dec, string color, double visualMag, int distance)
        {
            Name = name.Trim();
            Name2 = name2.Trim();
            RA = ra.Trim();
            Dec = dec;
            Color = color.Trim();
            VisualMag = visualMag;
            Distance = distance;
        }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string RA { get; set; }
        public double Dec { get; set; }
        public string Color { get; set; }
        public double VisualMag { get; set; }
        public int Distance { get; set; }

        public int RaInDegrees()
        {
            int ret = 0;
            int hours = Convert.ToInt32(RA.Substring(0, 2));
            int minutes = Convert.ToInt32(RA.Substring(3, 2));

            ret = (hours * 15) + (minutes / 4);

            return ret;
        }

        public Brush GetColor()
        {
            Brush br = Brushes.White;
            if (Color == "white")
            {
                br = Brushes.White;
            }
            else if (Color == "lyellow")
            {
                br = Brushes.LightYellow;
            }
            else if (Color == "yellow")
            {
                br = Brushes.Yellow;
            }
            else if (Color == "orange")
            {
                br = Brushes.Orange;
            }
            else if (Color == "lcyan")
            {
                br = Brushes.LightCyan;
            }
            else if (Color == "cyan")
            {
                br = Brushes.Cyan;
            }
            else if (Color == "red")
            {
                br = Brushes.Red;
            }
            return br;
        }

        public int CircleSize()
        {
            int i = 1;
            double vm = VisualMag;

            if (vm < 0)
            {
                i = 4;
            }
            else if (vm < 1)
            {
                i = 3;
            }
            else if (vm < 2)
            {
                i = 2;
            }

            return i; 
        }
    }
}
