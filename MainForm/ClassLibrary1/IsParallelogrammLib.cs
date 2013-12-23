using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace GeomLibrary
{
    public class Geometry
    {
        /// <summary>
        /// XML-комментарии позволяют создавать программисту документацию прямо из исходных файлов Visual Studio
        /// </summary>
        /// <param name="firstPoint">Задана 1-ая точка четырёхугольника</param>
        /// <param name="secondPoint">Задана 2-ая точка четырёхугольника</param>
        /// <param name="thirdPoint">Задана 3-я точка четырёхугольника</param>
        /// <param name="fourthPoint">Задана 4-ая точка четырёхугольника</param>
        /// <returns>Возвращается true/false в зависимости от того, является ли получившийся четырёхугольник параллелограммом</returns>
        static public bool IsParallelogramm(System.Drawing.Point firstPoint, System.Drawing.Point secondPoint, System.Drawing.Point thirdPoint, System.Drawing.Point fourthPoint)
        {
            Vector a = new Vector(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Vector b = new Vector(thirdPoint.X - secondPoint.X, thirdPoint.Y - secondPoint.Y);
            Vector c = new Vector(fourthPoint.X - thirdPoint.X, fourthPoint.Y - fourthPoint.Y);
            Vector d = new Vector(firstPoint.X - fourthPoint.X, firstPoint.Y - fourthPoint.Y);
            return ((Vector.CrossProduct(a, c) == 0) && (Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) == Math.Sqrt(Math.Pow(c.X, 2) + Math.Pow(c.Y, 2)))) || ((Vector.CrossProduct(b, d) == 0) && (Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2)) == Math.Sqrt(Math.Pow(d.X, 2) + Math.Pow(d.Y, 2))));
        }
    }
}
