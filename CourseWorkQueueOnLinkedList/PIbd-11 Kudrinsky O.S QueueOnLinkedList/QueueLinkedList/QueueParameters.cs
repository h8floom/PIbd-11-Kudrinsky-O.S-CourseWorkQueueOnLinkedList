﻿namespace PIbd_11_Kudrinsky_O.S_QueueOnLinkedList.QueueLinkedList;

public class QueueParameters
{
    // Максимальный размер очереди
    public int MaxSize { get; set; }

    public QueueParameters(int maxSize)
    {
        MaxSize = maxSize;
    }
}
