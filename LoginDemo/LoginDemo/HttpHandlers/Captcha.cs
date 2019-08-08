using LoginDemo.Base;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace LoginDemo
{
    public class Captcha : HttpSyncHandler
    {
        protected override void Get(HttpContext context)
        {
            /*
            string str = "hello world!";

            var randomInt = new Random().Next(10, 99);
            byte[] bytes;
            using (var stream = new System.IO.MemoryStream())
            {
                using (Image image = new Bitmap(150, 30))
                {
                    using (var gp = Graphics.FromImage(image))
                    {
                        Font font = new Font(FontFamily.GenericSerif, 15);
                        SolidBrush brush = new SolidBrush(Color.Black);
                        SolidBrush brush2 = new SolidBrush(Color.Gold);
                        gp.FillRectangle(brush2, 0, 0, image.Size.Width, image.Size.Height);
                        gp.DrawString(str + randomInt, font, brush, new PointF(5, 5));
                    }
                    image.Save(stream, ImageFormat.Png);
                }
                bytes = stream.ToArray();
            }*/

            var captcha = CaptchaDrawer.GenerateCaptchaImage(120, 30);
            context.Session.Remove(SessionKeys.Captcha);
            context.Session.Add(SessionKeys.Captcha, captcha.CaptchaCode);
            OK(Response, captcha.CaptchaByteData);
        }

        protected void OK(HttpResponse response, byte[] image)
        {
            response.ContentType = "image/png";
            response.BinaryWrite(image);
        }
    }
}