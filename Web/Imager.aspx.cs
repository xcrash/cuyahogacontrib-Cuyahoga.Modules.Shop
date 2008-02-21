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
using System.IO;

using System.Net;
using System.Text.RegularExpressions;

using Cuyahoga.Web.Util;
using Cuyahoga.Core.Util;
using Cuyahoga.Web.UI;
using Cuyahoga.Modules.Shop;
using Cuyahoga.Modules.Shop.Domain;
using Cuyahoga.Modules.Shop.Utils;

namespace Cuyahoga.Modules.Shop.Web
{
    public partial class Imager : BaseModuleControl
    {
        private ShopModule _module;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this._module = base.Module as ShopModule;
                if (Request.QueryString["ImageId"] != null)
                {

                    MemoryStream ms = new MemoryStream(this._module.GetShopImageById(int.Parse(Request.QueryString["ImageId"])).Data);

                    Bitmap bmpImage = new Bitmap(ms);
                    byte[] bufferImage;

                    int x = bmpImage.Width;
                    int y = bmpImage.Height;

                    if (Request.QueryString["ImageOutputWidth"] != null)
                    {
                        x = int.Parse(Request.QueryString["ImageOutputWidth"]);
                        y = (x * bmpImage.Height) / bmpImage.Width;
                    }

                    if (x < bmpImage.Width || y < bmpImage.Height)
                    {
                        Size scale = new Size(x, y);
                        bmpImage = new Bitmap(bmpImage, scale);
                    }

                    ms = new MemoryStream();
                    bmpImage.Save(ms, ImageFormat.Jpeg);

                    bufferImage = new byte[(int)ms.Length];

                    ms.Position = 0;
                    for (int i = 0; i < (int)ms.Length; i++)
                    {
                        bufferImage[i] = (byte)ms.ReadByte();
                    }
                 
                    this.Response.BinaryWrite(bufferImage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
