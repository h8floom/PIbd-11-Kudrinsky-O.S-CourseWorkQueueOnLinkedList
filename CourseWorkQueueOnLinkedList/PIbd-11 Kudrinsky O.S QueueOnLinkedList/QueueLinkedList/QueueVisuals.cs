using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList
{
    public class QueueVisualizer
    {
        public void Visualize(QueueState state, Form form)
        {
            PictureBox pictureBox = form.Controls["pictureBox1"] as PictureBox;

            if (pictureBox == null)
            {
                MessageBox.Show("PictureBox не найден на форме.");
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                int[] queue = state.Array;
                int rectangleHeight = 50; // высота прямоугольника
                const int distanceBetweenElements = 20; // расстояние между элементами

                // Вычисление максимальной ширины каждого прямоугольника
                int[] rectangleWidths = new int[queue.Length];
                using (Font font = new Font("Tahoma", 14))
                {
                    for (int i = 0; i < queue.Length; i++)
                    {
                        string text = queue[i].ToString();
                        SizeF textSize = graphics.MeasureString(text, font);
                        int textWidth = (int)textSize.Width + 10;
                        int numberWidth = TextRenderer.MeasureText(queue[i].ToString(), font).Width + 10;
                        rectangleWidths[i] = Math.Max(100, Math.Max(textWidth, numberWidth));
                    }
                }

                // Вычисление начальных координат
                int x = 10; // Начальная позиция по оси X для выравнивания по левому краю
                int y = (pictureBox.Height - rectangleHeight) / 2; // Центрирование по оси Y

                int headX = -1, tailX = -1; // Объявление переменных для хранения координат головы и хвоста очереди

                for (int i = 0; i < queue.Length; i++)
                {
                    int rectangleWidth = rectangleWidths[i];

                    // Проверка, поместится ли следующий элемент в текущей строке
                    if (x + rectangleWidth > pictureBox.Width)
                    {
                        // Перенос на новую строку
                        x = 10;
                        y += rectangleHeight + distanceBetweenElements + 10;
                    }

                    // Отрисовка элемента очереди
                    DrawQueueElement(graphics, x, y, rectangleWidth, rectangleHeight, queue[i]);

                    // Определение координат головы и хвоста очереди
                    if (i == 0)
                    {
                        headX = x + rectangleWidth / 2;
                    }
                    if (i == queue.Length - 1)
                    {
                        tailX = x + rectangleWidth / 2;
                    }

                    // Отрисовка указателя на следующий элемент, если это не последний элемент
                    if (i < queue.Length - 1)
                    {
                        int arrowStartX = x + rectangleWidth + distanceBetweenElements / 2;
                        int arrowEndX = arrowStartX + distanceBetweenElements;
                        int arrowY = y + rectangleHeight / 2;
                        DrawArrow(graphics, arrowStartX, arrowY, arrowEndX, arrowY);

                        // Пересчет координат следующего прямоугольника
                        x = arrowEndX + distanceBetweenElements / 2;
                    }
                    else
                    {
                        // Если это последний элемент, учитываем только ширину текущего прямоугольника
                        x += rectangleWidth + distanceBetweenElements;
                    }
                }

                // Визуализация указателей на голову и хвост
                if (headX != -1)
                {
                    DrawPointerWithArrow(graphics, "Head", headX, (pictureBox.Height - rectangleHeight) / 2 - 20);
                }
                if (tailX != -1)
                {
                    DrawPointerWithArrow(graphics, "Tail", tailX, y + rectangleHeight + 20);
                }
            }

            pictureBox.Image = bitmap;
        }

        private void DrawQueueElement(Graphics graphics, int x, int y, int width, int height, int item)
        {
            // Текст внутри прямоугольника
            string text = item.ToString();
            using (Font font = new Font("Tahoma", 14))
            {
                SizeF textSize = graphics.MeasureString(text, font);

                // Прямоугольник
                graphics.FillRectangle(Brushes.LightBlue, x, y, width, height);
                graphics.DrawRectangle(Pens.Black, x, y, width, height);

                // Определение позиции текста внутри прямоугольника
                float textX = x + (width - textSize.Width) / 2;
                float textY = y + (height - textSize.Height) / 2;

                // Отрисовка текста
                graphics.DrawString(text, font, Brushes.Black, textX, textY);
            }
        }

        private void DrawArrow(Graphics graphics, int startX, int startY, int endX, int endY)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // Рассчитываем угол наклона стрелки
                double angle = Math.Atan2(endY - startY, endX - startX);

                // Рассчитываем координаты точки, отстоящей от конечной точки на длину стрелочки
                int arrowLength = 10;
                int arrowEndX = endX - (int)(arrowLength * Math.Cos(angle));
                int arrowEndY = endY - (int)(arrowLength * Math.Sin(angle));

                // Нарисовать линию до точки, отстоящей на длину стрелочки
                graphics.DrawLine(pen, startX, startY, arrowEndX, arrowEndY);

                // Нарисовать саму стрелочку
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                pen.CustomEndCap = bigArrow;
                graphics.DrawLine(pen, arrowEndX, arrowEndY, endX, endY);
            }
        }

        private void DrawPointerWithArrow(Graphics graphics, string text, int x, int y)
        {
            // Отрисовка стрелки
            if (text == "Head")
            {
                graphics.DrawLine(Pens.Black, x, y - 20, x, y);
                graphics.DrawLine(Pens.Black, x, y, x + 5, y - 5);
                graphics.DrawLine(Pens.Black, x, y, x - 5, y - 5);
            }
            else if (text == "Tail")
            {
                graphics.DrawLine(Pens.Black, x, y + 20, x, y); // Изменение направления стрелки
                graphics.DrawLine(Pens.Black, x, y, x + 5, y + 5); // Изменение направления стрелки
                graphics.DrawLine(Pens.Black, x, y, x - 5, y + 5); // Изменение направления стрелки
            }

            // Отрисовка текста
            using (Font font = new Font("Tahoma", 10))
            {
                SizeF textSize = graphics.MeasureString(text, font);
                float textX = x - textSize.Width / 2;
                float textY = (text == "Head") ? y - 30 - textSize.Height : y + 30;
                graphics.DrawString(text, font, Brushes.Black, textX, textY);
            }
        }
    }
}