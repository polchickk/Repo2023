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
                "Поворот на 90 против часовой стрелки",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));


            mainForm.AddFilter(new TransformFilter(
               "Поворот на 90 по часовой стрелки",
               size => new Size(size.Height, size.Width),
               (point, size) => new Point(point.Y, size.Height - point.X - 1)
               ));

            mainForm.AddFilter(new TransformFilter(
              "Поворот на 180",
              size => new Size(size.Width, size.Height),
              (point, size) => new Point(size.Width- point.X-1, size.Height - point.Y - 1)
              ));

            mainForm.AddFilter(new TransformFilter(
             "Поворот по вертикали",
             size => new Size(size.Width, size.Height),
             (point, size) => new Point (point.X,size.Height - point.Y - 1)
             ));

            mainForm.AddFilter(new TransformFilter(
            "Зеркальное отражение относительно побочной диагонали",
            size => new Size(size.Height, size.Width),
            (point, size) => new Point(size.Width-1- point.Y,size.Height-1- point.X )
            ));

            mainForm.AddFilter(new TransformFilter(
           "Отражение относительно центра",
           size => new Size(size.Width, size.Height),
           (point, size) => new Point(size.Width - 1 - point.X, size.Height - 1 - point.Y)
           ));

            mainForm.AddFilter(new TransformFilter(
            "Отражение относительно главной диагонали",
            size => new Size(size.Height, size.Width),
            (point, size) => new Point(point.Y, point.X)
            ));

            mainForm.AddFilter(new TransformFilter(
               "Отражение по горизонтали",
               size => new Size(size.Width, size.Height),
               (point, size) => new Point(size.Width - point.X - 1, point.Y)
               ));

            //mainForm.AddFilter(new TransformFilter(
            //   "Мозаика",
            //  size => new Size(size.Width * 2, size.Height * 2),
            //   (point, size) =>
            //   {
            //       if (point.X < size.Width * 0.5 && point.Y < size.Height * 0.5)
            //           return point = new Point(point.X, point.Y);
            //       else if (point.Y > size.Height * 0.5 && point.X < size.Width * 0.5)
            //           return point = new Point(size.Width - point.X - 1, point.Y);
            //       else if ((point.Y < size.Height * 0.5) && (point.X > size.Width * 0.5))
            //           return point = new Point(point.X, size.Height - point.Y - 1);
            //       else
            //           return point = new Point(point.Y, point.X);
            //   }
            //   ));


                   //Func<Point, Size, EmptyParameters, Point> pointMosaic =
                   //     (point, oldSize, parameters) =>
                   //     {
                   //         if (point.X < oldSize.Width * 0.5 && point.Y < oldSize.Height * 0.5)
                   //             return point = new Point(point.X, point.Y);
                   //         else if (point.Y > oldSize.Height * 0.5 && point.X < oldSize.Width * 0.5)
                   //             return point = new Point(oldSize.Width - point.X - 1, point.Y);
                   //         else if ((point.Y < oldSize.Height * 0.5) && (point.X > oldSize.Width * 0.5))
                   //             return point = new Point(point.X, oldSize.Height - point.Y - 1);
                   //         else
                   //             return point = new Point(point.Y, point.X);
                   //     };

                   //Func<Size, EmptyParameters, Size> sizeMosaic = (size, parameters) =>
                   //{
                   //    return new Size(size.Width*2, size.Height*2);
                   //};
                   //mainForm.AddFilter(new TransformFilter(
                   //    "Мозаика",
                   //    sizeMosaic,
                   //    pointMosaic
                   //    ));

                   mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол",
               new RotateTransformer()
                ));

            mainForm.AddFilter(new TransformFilter<LeftParameters>(
                "Скос влево",
               new LeftTransformer()
                ));
           


            Application.Run(mainForm);
        }
    }
}
