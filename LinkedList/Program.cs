using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyLinkedList<string> list = new MyLinkedList<string>();
            int choice = -1;
            string sentence = "Вот и лето прошло, словно и не бывало.";
            char[] letter;

            letter = sentence.ToCharArray();
            foreach (char l in letter)
            {
                if (l != ' ')
                {
                    list.Add(l.ToString());
                }
            }

            int position;
            string data;
            Console.WriteLine("Элементы листа: "); list.Print(); Console.WriteLine("\n");
            Console.WriteLine("1) Добавление элемента в конец списка.\n2) Добавление элемента в начало списка.\n3) Добавление элемента в определенную позицию.\n4) Удаление элемента по его значению.\n5) Удаление элемента по его номеру в односвязном списке.\n6) Очистка списка.\n7) Поиска номера элемента в списке.\n8) Просмотр списка.");

            while (choice != 0)
            {
                Console.WriteLine("\n\nВведите номер пункта меню, который хотите осуществить:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите значение:");
                            data = Console.ReadLine();
                            list.Add(data);
                            list.Print();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Введите значение:");
                            data = Console.ReadLine();
                            list.AddToStart(data);
                            list.Print();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Введите позицию и значение:");
                            position = Convert.ToInt32(Console.ReadLine());
                            data = Console.ReadLine();
                            list.AddToPosition(position, data);
                            list.Print();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Введите значение:");
                            data = Console.ReadLine();
                            list.DeleteByValue(data);
                            list.Print();
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Введите номер элемента в списке:");
                            position = Convert.ToInt32(Console.ReadLine());
                            list.DeleteByPosition(position);
                            list.Print();
                        }
                        break;
                    case 6:
                        {
                            list.Clear();
                            list.Print();
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("Введите значение:");
                            data = Console.ReadLine();
                            list.FindPosition(data);
                        }
                        break;
                    case 8:
                        {
                            list.Print();
                        }
                        break;
                    default: break;
                }
            }

        }
    }


}


public class MyLinkedList<T>
{
    public class Node<E>
    {
        E data;
        public Node<E> Next;
        public Node(E data)
        {
            this.data = data;
        }

        public Node() { }

        public override string ToString()
        {
            return this.data.ToString();
        }

    }

    public Node<T> head;
    public Node<T> tail;
    int count;

    public void Add(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
        {
            head = node;
            tail = head;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }
        count++;
    }

    public void AddToStart(T data)
    {
        Node<T> node = new Node<T>(data);

        if (head == null)
            head = node;
        else
        {
            node.Next = head;
            head = node;
        }

    }

    public void Print()
    {
        Node<T> current;

        if (head != null && head.Next != null)
        {
            Console.Write(head.ToString() + " ");
            current = head.Next;
            Console.Write(current.ToString() + " ");

            while (current.Next != null)
            {
                current = current.Next;
                Console.Write(current.ToString() + " ");
            }
        }

        else
        {
            if (head != null)
            {
                Console.WriteLine(head.ToString());
            }
            else
            {
                Console.WriteLine("Error: no elements in list");
            }
        }

    }
    public void DeleteByValue(T data)
    {
        Node<T> current;
        Node<T> previous;

        current = head;
        previous = current;

        while (current.Next != null)
        {

            if (current.ToString().Equals(data.ToString()))
            {
                if (current != head)
                {
                    previous.Next = current.Next;
                    break;
                }
                else
                {
                    head = head.Next;
                }
            }
            else
            {
                previous = current;
                current = current.Next;
            }


        }
        if (current.Next == null && current.ToString().Equals(data.ToString()))
        {
            previous.Next = null;
            tail = previous;
        }

    }
    public void FindPosition(T data)
    {
        Node<T> current;
        int count = 1;
        current = head;
        if (current.ToString().Equals(data.ToString()))
        {
            Console.WriteLine($"Position number is:{count}");
        }
        else
        {
            
            while (current.Next != null)
            {
                if (current.ToString().Equals(data.ToString()))
                {
                    Console.WriteLine($"Position number is:{count}");
                    break;
                }
                current = current.Next;
                count++;
            }
            if (current.Next == null && current.ToString().Equals(data.ToString())) 
            {
                Console.WriteLine($"Position number is:{count}");
               
            }
        }
    }

    public void Clear()
    {
        head = null;
    }

    public void AddToPosition(int position, T data)
    {
        Node<T> current;
        Node<T> previous;
        Node<T> newnode = new Node<T>(data);

        count = 1;
        if (position == 1)
        {
            AddToStart(data);

        }

        if (head != null && head.Next != null)
        {
            previous = head;
            current = head.Next;
                     
            count = 2;


            if (count != 1)
            {
                while (current.Next != null)
                {
                    if (count == position)
                    {
                        newnode.Next = current;
                        previous.Next = newnode;
                        break;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                        count += 1;
                    }

                    if (current.Next == null && (count < position || position == 0 || position < 0))
                    {
                        Console.WriteLine("Position has been out of LinkedList");
                        break;
                    }
                }
                if (current.Next == null)
                {
                    previous = current;
                    current = current.Next;

                    previous.Next = newnode;
                    newnode.Next = current;
                    tail = current;
                }
            }

        }
        if (head == null)
        {
            Console.WriteLine("There are no existing LinkedList");
        }
    }

    public void DeleteByPosition(int position)
    {
        Node<T> current;
        Node<T> previous;

        if (position > 0 && position != 0)
        {
            previous = head;
            current = head.Next;
            count = 1;

            if (count == 1 && position == 1)
            {
                head = current;
            }
            else
            {
                count = 2;
            }
            while (current.Next != null)
            {
                if (position == count && position != 1)
                {
                    previous.Next = current.Next;
                    break;
                }
                previous = current;
                current = current.Next;
                count++;
            }
            if (current.Next == null && position == count)
            {
                previous.Next = null;
                tail = previous;
            }

        }
        else
            Console.WriteLine("Position is out of LinkedList");
    }

}


