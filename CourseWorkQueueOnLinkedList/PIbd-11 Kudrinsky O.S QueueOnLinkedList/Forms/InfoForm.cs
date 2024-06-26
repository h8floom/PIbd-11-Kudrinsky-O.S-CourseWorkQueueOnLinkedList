﻿namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.Forms;

public partial class InfoForm : Form
{
    public InfoForm()
    {
        InitializeComponent();
        LoadProgramInfo();
    }

    private void LoadProgramInfo()
    {
        string programInfoText = "Описание программы:\n\n" +
                                 "Программа реализует абстрактный тип данных (АТД) \"очередь\" на основе односвязного списка. Очередь - это структура данных, работающая по принципу FIFO (First In, First Out), где первым добавленным элементом будет первым извлеченным. Реализация на односвязном списке обеспечивает эффективные операции добавления и удаления элементов из начала и конца очереди." +
                                 "" +
                                 "" +
                                 "\n\n\n\n" +
                                 "" +
                                 "Принцип работы\r\n\r\nПрограмма состоит из следующих ключевых компонентов:\r\n\r\n1)QueueLinkedList: Класс, реализующий саму очередь на основе односвязного списка. Включает в себя методы для добавления элементов в конец очереди (Enqueue), удаления элементов из начала очереди (Dequeue), а также другие вспомогательные методы.\r\n\r\n2)QueueState: Класс, представляющий состояние очереди в определенный момент времени. Каждое состояние содержит массив элементов, представляющих текущее состояние очереди.\r\n\r\n3)QueueManager: Класс, отвечающий за управление операциями с очередью. Включает в себя методы для выполнения операций добавления и удаления элементов, а также методы для получения состояний очереди и их сохранения.\r\n\r\n4)QueueVisualizer: Класс, отвечающий за визуализацию состояний очереди на форме. Предоставляет метод Visualize, который рисует текущее состояние очереди на элементе управления PictureBox." +
                                 "" +
                                 "" +
                                 "\n\n\n\n" +
                                 "" +
                                 "Пример использования\r\n\r\nПрограмма позволяет добавлять и удалять элементы из очереди, а также визуализировать текущее состояние очереди на форме. Пользователь может взаимодействовать с программой, добавляя и удаляя элементы, и наблюдая, как меняется состояние очереди в реальном времени.";

        richTextBoxInfo.Text = programInfoText;

    }
}

