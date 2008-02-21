using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.ComponentModel;
using System.Collections;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;

using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Web.Util;

namespace Cuyahoga.Modules.Shop.Utils
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public Utils()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string BadWordReplace(object o)
		{
			return "";
		}

        public static Bitmap ImageResize(Byte[] imagein, int width)
        {

            MemoryStream ms = new MemoryStream();
            ms.Write(imagein, 0, imagein.Length);
            Bitmap bmpImage = (Bitmap)System.Drawing.Image.FromStream(ms);
           
            /*
            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            // for the Quality parameter category.
            Encoder myEncoder = Encoder.Quality;

            // Save the bitmap as a JPEG file with quality level 75.
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 92L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            ms = new MemoryStream();
            bmpImage.Save(ms, myImageCodecInfo, myEncoderParameters);
            
            bmpImage = (Bitmap)System.Drawing.Image.FromStream(ms);
            */

            int x = bmpImage.Width;
            int y = bmpImage.Height;

            x = width;
            y = (x * bmpImage.Height) / bmpImage.Width;

            if (x < bmpImage.Width || y < bmpImage.Height)
            {
                Bitmap thumb = new Bitmap(x,y);
                Graphics g = Graphics.FromImage(thumb);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmpImage, 0, 0, x, y);
                bmpImage = thumb;
            }

            return bmpImage;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


		public static DataTable TimeZones() 
		{
			using(DataTable dt = new DataTable("TimeZone")) 
			{
				dt.Columns.Add("Value",Type.GetType("System.Int32"));
				dt.Columns.Add("Name",Type.GetType("System.String"));

				dt.Rows.Add(new object[]{-720,"(GMT - 12:00) Enitwetok, Kwajalien"});
				dt.Rows.Add(new object[]{-660,"(GMT - 11:00) Midway Island, Samoa"});
				dt.Rows.Add(new object[]{-600,"(GMT - 10:00) Hawaii"});
				dt.Rows.Add(new object[]{-540,"(GMT - 9:00) Alaska"});
				dt.Rows.Add(new object[]{-480,"(GMT - 8:00) Pacific Time (US & Canada)"});
				dt.Rows.Add(new object[]{-420,"(GMT - 7:00) Mountain Time (US & Canada)"});
				dt.Rows.Add(new object[]{-360,"(GMT - 6:00) Central Time (US & Canada), Mexico City"});
				dt.Rows.Add(new object[]{-300,"(GMT - 5:00) Eastern Time (US & Canada), Bogota, Lima, Quito"});
				dt.Rows.Add(new object[]{-240,"(GMT - 4:00) Atlantic Time (Canada), Caracas, La Paz"});
				dt.Rows.Add(new object[]{-210,"(GMT - 3:30) Newfoundland"});
				dt.Rows.Add(new object[]{-180,"(GMT - 3:00) Brazil, Buenos Aires, Georgetown, Falkland Is."});
				dt.Rows.Add(new object[]{-120,"(GMT - 2:00) Mid-Atlantic, Ascention Is., St Helena"});
				dt.Rows.Add(new object[]{-60,"(GMT - 1:00) Azores, Cape Verde Islands"});
				dt.Rows.Add(new object[]{0,"(GMT) Casablanca, Dublin, Edinburgh, London, Lisbon, Monrovia"});
				dt.Rows.Add(new object[]{60,"(GMT + 1:00) Berlin, Brussels, Kristiansund, Madrid, Paris, Rome"});
				dt.Rows.Add(new object[]{120,"(GMT + 2:00) Kaliningrad, South Africa, Warsaw"});
				dt.Rows.Add(new object[]{180,"(GMT + 3:00) Baghdad, Riyadh, Moscow, Nairobi"});
				dt.Rows.Add(new object[]{210,"(GMT + 3:30) Tehran"});
				dt.Rows.Add(new object[]{240,"(GMT + 4:00) Adu Dhabi, Baku, Muscat, Tbilisi"});
				dt.Rows.Add(new object[]{270,"(GMT + 4:30) Kabul"});
				dt.Rows.Add(new object[]{300,"(GMT + 5:00) Ekaterinburg, Islamabad, Karachi, Tashkent"});
				dt.Rows.Add(new object[]{330,"(GMT + 5:30) Bombay, Calcutta, Madras, New Delhi"});
				dt.Rows.Add(new object[]{360,"(GMT + 6:00) Almaty, Colomba, Dhakra"});
				dt.Rows.Add(new object[]{420,"(GMT + 7:00) Bangkok, Hanoi, Jakarta"});
				dt.Rows.Add(new object[]{480,"(GMT + 8:00) Beijing, Hong Kong, Perth, Singapore, Taipei"});
				dt.Rows.Add(new object[]{540,"(GMT + 9:00) Osaka, Sapporo, Seoul, Tokyo, Yakutsk"});
				dt.Rows.Add(new object[]{570,"(GMT + 9:30) Adelaide, Darwin"});
				dt.Rows.Add(new object[]{600,"(GMT + 10:00) Melbourne, Papua New Guinea, Sydney, Vladivostok"});
				dt.Rows.Add(new object[]{660,"(GMT + 11:00) Magadan, New Caledonia, Solomon Islands"});
				dt.Rows.Add(new object[]{720,"(GMT + 12:00) Auckland, Wellington, Fiji, Marshall Island"});
				return dt;
			}
		}
	}
}
