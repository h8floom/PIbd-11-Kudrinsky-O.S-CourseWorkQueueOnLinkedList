using PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.States;

namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;

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
            int rectangleWidth = 155;
            int rectangleHeight = 40;
            const int distanceBetweenElements = 20;

            int i = 0;
            foreach (var item in queue)
            {
                int x = 10 + i * (rectangleWidth + distanceBetweenElements);
                int y = (pictureBox.Height - rectangleHeight) / 2;

                // Проверяем, помещается ли элемент в область визуализации
                if (x + rectangleWidth <= pictureBox.Width)
                {
                    // Рисуем прямоугольник только если он помещается в область
                    graphics.FillRectangle(Brushes.LightBlue, x, y, rectangleWidth, rectangleHeight);
                    graphics.DrawRectangle(Pens.Black, x, y, rectangleWidth, rectangleHeight);

                    // Рисуем текст внутри прямоугольника
                    string text = item.ToString();
                    using (Font font = new Font("Tahoma", 10))
                    {
                        SizeF textSize = graphics.MeasureString(text, font);
                        float textX = x + (rectangleWidth - textSize.Width) / 2;
                        float textY = y + (rectangleHeight - textSize.Height) / 2;
                        graphics.DrawString(text, font, Brushes.Black, textX, textY);
                    }
                }
                else
                {
                    // Если элемент не помещается, выдаем сообщение пользователю
                    MessageBox.Show("Невозможно добавить элемент в очередь. Превышен размер формы.");
                    break;
                }

                i++;
            }
        }

        pictureBox.Image = bitmap;
    }


}

