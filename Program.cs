using System;
using System;

public class QueueNode
{
    public int Value { get; set; }  // Düğümün değerini temsil eden özellik.
    public QueueNode Next { get; set; }  // Bir sonraki düğüme işaret eden özellik.

    public QueueNode(int value)
    {
        Value = value;  // Düğümün değerini ayarlayan yapıcı metot.
        Next = null;  // Başlangıçta bir sonraki düğüm null olarak ayarlanır.
    }
}

public class Queue
{
    private QueueNode _head;  // Kuyruğun başını temsil eden düğüm.
    private QueueNode _tail;  // Kuyruğun sonunu temsil eden düğüm.

    public Queue()
    {
        _head = null;
        _tail = null;
    }

    public void Enqueue(int value)
    {
        QueueNode newNode = new QueueNode(value);

        if (_head == null)  // Kuyruk boşsa...
        {
            _head = newNode;  // Yeni düğümü hem başa hem de sona ata.
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;  // Son düğümün Next özelliğini yeni düğüme bağla.
            _tail = newNode;  // Yeni düğümü sona ata.
        }
    }

    public int Dequeue()
    {
        if (_head == null)  // Kuyruk boşsa...
        {
            throw new Exception("Kuyruk boş.");
        }

        int dequeuedValue = _head.Value;  // Baş düğümün değerini al.

        _head = _head.Next;  // Baş düğümü bir sonraki düğüme ilerlet.

        if (_head == null)  // Baş düğüm null ise, kuyruğun sonuna gelinmiştir.
        {
            _tail = null;  // Son düğümü de null olarak ayarla.
        }

        return dequeuedValue;  // Çıkarılan değeri döndür.
    }

    public void Print()
    {
        QueueNode currentNode = _head;

        while (currentNode != null)  // Düğüm null olana kadar dön.
        {
            Console.Write("{0} ", currentNode.Value);  // Düğümün değerini ekrana yazdır.
            currentNode = currentNode.Next;  // Bir sonraki düğüme geç.
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue queue = new Queue();

        while (true)
        {
            Console.WriteLine("1 - Kuyruğa eleman ekle");
            Console.WriteLine("2 - Kuyruktan eleman çıkar");
            Console.WriteLine("3 - Kuyruğu yazdır");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminiz: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Eklenecek değer: ");
                    int value = int.Parse(Console.ReadLine()); 
                    queue.Enqueue(value);  // Kuyruğa eleman ekleme işlemi.
                    break;
                case 2:
                    try
                    {
                        int dequeuedValue = queue.Dequeue();  // Kuyruktan eleman çıkarma işlemi.
                        Console.WriteLine("Çıkarılan değer: {0}", dequeuedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);  // Hata durumunda mesajı ekrana yazdır.
                    }
                    break;
                case 3:
                    queue.Print();  // Kuyruğu yazdırma işlemi.
                    break;
                case 4:
                    return;  // Programı sonlandır.
                default:
                    Console.WriteLine("Geçersiz seçenek.");  // Geçersiz seçenek durumunda mesajı ekrana yazdır.
                    break;
            }
        }
    }
}

