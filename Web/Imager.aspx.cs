using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Cuyahoga.Web.Util;

namespace Cuyahoga.Modules.Shop.Web
{
    public partial class Imager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Image"] != null)
                {
                    Bitmap objImage = new Bitmap(HttpContext.Current.Request.PhysicalApplicationPath + Request.QueryString["Image"]);
                    if (Request.QueryString["ImageOutputWidth"] != null)
                    {
                        int iWidth = int.Parse(Request.QueryString["ImageOutputWidth"]);
                        Bitmap objImage2 = new Bitmap(objImage, iWidth, (objImage.Height * iWidth) / objImage.Width);
                        objImage = objImage2;
                    }
                    objImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                    /*
                    if ( objImage.RawFormat.Equals( ImageFormat.Jpeg ) )
                    {
                        objImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                    }
                    else if (objImage.RawFormat.Equals(ImageFormat.Gif))
                    {
                        objImage.Save(Response.OutputStream, ImageFormat.Gif);
                    }
                    else if (objImage.RawFormat.Equals(ImageFormat.Bmp))
                    {
                        objImage.Save(Response.OutputStream, ImageFormat.Bmp);
                    }
                    else if (objImage.RawFormat.Equals(ImageFormat.Png))
                    {
                        objImage.Save(Response.OutputStream, ImageFormat.Png);
                    }
                    else
                    {
                        Response.Write("Wrong image format: " + objImage.RawFormat.ToString());
                    }
                     * */

                    objImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
