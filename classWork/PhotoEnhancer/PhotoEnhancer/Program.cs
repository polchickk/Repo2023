﻿using PhotoEnhancer.Filters;
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

            mainForm.AddFilter(new TransformFilter(
                "Мозаика",
                oldSize => new Size(oldSize.Width * 2, oldSize.Height * 2),
                (newPoint, oldSize) =>
                {
                    if (newPoint.X < oldSize.Width && newPoint.Y < oldSize.Height)
                        return newPoint = new Point(newPoint.X, newPoint.Y);
                    else if (newPoint.Y >= oldSize.Height && newPoint.X < oldSize.Width)
                        return newPoint = new Point(newPoint.X, 2 * oldSize.Height - newPoint.Y - 1);
                    else if (newPoint.Y < oldSize.Height && newPoint.X >= oldSize.Width)
                        return newPoint = new Point(2 * oldSize.Width - newPoint.X - 1, newPoint.Y);
                    else
                        return newPoint = new Point(2 * oldSize.Width - newPoint.X - 1, 2 * oldSize.Height - newPoint.Y - 1);
                }
                ));


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
