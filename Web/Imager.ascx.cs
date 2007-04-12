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

namespace Cuyahoga.Modules.Shop.Web
{
    public partial class Imager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Image"] != null)
                {
                    Bitmap objImage = new Bitmap(Request.QueryString["Image"]);
                    objImage.Save(Response.OutputStream, ImageFormat.Jpeg);
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