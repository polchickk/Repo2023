using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;



namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                   "Осветление/затемнение",
                   (pixel, parameters) => pixel * parameters.Coefficient));
           
            mainForm.AddFilter( new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters)=>
                {
                    var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                    return new Pixel(lightness, lightness, lightness);
                }));

            mainForm.AddFilter(new PixelFilter<InvertParameters>(
                "Инверсия",
                (Pixel pixel, InvertParameters parameters)=>~pixel));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90 против часовой стрелки",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter(
               "Поворот на 90 по часовой стрелки",
               size => new Size(size.Height, size.Width),
               (point, size) => new Point(point.Y, size.Height - point.X - 1)
               ));


            Func<Point, Size, EmptyParameters, Point?> pointMosaic =
                 (point, oldSize, parameters) =>
                 {
                     point=new Point(point.X, oldSize.Height - point.Y - 1);

                     return point;
                 };

            Func<Size, EmptyParameters, Size> sizeMosaic = (size, parameters) =>
            {
                return new Size(size.Width, size.Height);
            };

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол",
               new RotateTransformer()
                ));

            //mainForm.AddFilter(new TransformFilter<EmptyParameters>(
            //    "Отражение по горизонтали",
            //    sizeMosaic,
            //    pointMosaic
            //    ));

            Application.Run(mainForm);
        }
    }
}
