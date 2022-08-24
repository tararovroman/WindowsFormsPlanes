﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WindowsFormsPlanes
{
    /// <summary>
    /// Класс отрисовки истребителя
    /// </summary>
    public class Istrebitel : WarPlane
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия ракет
        /// </summary>
        public bool Rockets { private set; get; }

        /// <summary>
        /// Признак наличия пулемета
        /// </summary>
        public bool Machinegun { private set; get; }

        /// <summary>
        /// Признак наличия турбины
        /// </summary>
        public bool Turbine { private set; get; }

        /// <summary>
        /// Признак наличия линий
        /// </summary>
        public bool Lines { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес самолета</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="rockets">Признак наличия ракет</param>
        /// <param name="machinegun">Признак наличия пулемета</param>
        /// <param name="turbine">Признак наличия турбины</param>
        /// <param name="lines">Признак наличия турбины</param>
        public Istrebitel(int maxSpeed, float weight, Color mainColor, Color dopColor, bool rockets, bool machinegun, bool turbine, bool lines) : base(maxSpeed, weight, mainColor, 190, 170)
        {
            DopColor = dopColor;
            Rockets = rockets;
            Machinegun = machinegun;
            Turbine = turbine;
            Lines = lines;
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush dopBrush = new SolidBrush(DopColor);
            Brush brBlack = new SolidBrush(Color.Black);


            // ракеты
            if (Rockets)
            {
                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 60, 10, 10);
                g.DrawLine(pen, _startPosX + 90, _startPosY + 60, _startPosX + 80, _startPosY + 65);
                g.DrawLine(pen, _startPosX + 80, _startPosY + 65, _startPosX + 90, _startPosY + 70);
                g.DrawLine(pen, _startPosX + 90, _startPosY + 70, _startPosX + 90, _startPosY + 60);

                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 130, 10, 10);
                g.DrawLine(pen, _startPosX + 90, _startPosY + 130, _startPosX + 80, _startPosY + 135);
                g.DrawLine(pen, _startPosX + 80, _startPosY + 135, _startPosX + 90, _startPosY + 140);
                g.DrawLine(pen, _startPosX + 90, _startPosY + 140, _startPosX + 90, _startPosY + 130);

                g.FillRectangle(brBlack, _startPosX + 90, _startPosY + 60, 10, 10);
                g.FillRectangle(brBlack, _startPosX + 90, _startPosY + 130, 10, 10);

            }

            // пулемет
            if (Machinegun)
            {
                g.DrawLine(pen, _startPosX + 30, _startPosY + 100, _startPosX + 20, _startPosY + 100);

            }

            // турбина
            if (Turbine)
            {
                g.DrawRectangle(pen, _startPosX + 180, _startPosY + 95, 2, 10);
                g.FillRectangle(brBlack, _startPosX + 180, _startPosY + 95, 2, 10);
            }

            // теперь отрисуем основу
            base.DrawTransport(g);

            // линии
            if (Lines)
            {
                g.DrawRectangle(pen, _startPosX + 130, _startPosY + 90, 5, 20);
                g.DrawRectangle(pen, _startPosX + 140, _startPosY + 90, 5, 20);

                g.FillRectangle(dopBrush, _startPosX + 130, _startPosY + 90, 5, 20);
                g.FillRectangle(dopBrush, _startPosX + 140, _startPosY + 90, 5, 20);
            }
        }
    }
}
