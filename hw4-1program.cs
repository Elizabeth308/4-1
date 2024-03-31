using System;
using System.Collections;

public sealed class OneDimensionMassive<T>
{
    private T[] array;
    public int Length 
    {
        get
        {
            return _size;
        } 
        set
        {

        } 
    }
    private Random random = new Random();
    private int _size;
    private int _capacity;

    public OneDimensionMassive(int capacity) 
    {
        array = new T[capacity];
        _capacity = capacity;
        _size = 0;
    }

    public OneDimensionMassive():this(7)
    {

    }

    public void AddElement(T element)
    {
        if(_size >= _capacity)
        {
            _capacity = 2 * _capacity + 1;
            T[] newarray = new T[_capacity];
            Array.Copy(array, newarray, _size);
            array = newarray;
        }
        array[_size] = element;
        _size++;
    }

    public void Print()
    {
        Console.WriteLine("Array");
        for (int i = 0; i < _size; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    public void DeleteElement(int indexofelement)
    {
        if(indexofelement <= _size)
        {
            T[] newarray = new T[_capacity];
            for (int i = 0; i < _size; i++)
            {
                if (i < indexofelement)
                {
                    newarray[i] = array[i];
                }
                else if (i > indexofelement)
                {
                    newarray[i-1] = array[i];
                }
            }
            _size--;
            array = newarray;
        }
        else
        {
            Console.WriteLine("Out of range");
        }
    }

    public void SortArray()
    {
        Array.Sort(array, 0, _size);
    }

    public bool IfOneElement(Func<T, bool> action)
    {
        for (int i = 0; i < _size; i++)
        {
            if (action(array[i]))
            {
                return true;
            }
        }
        return false;
    }
    public bool IfAllElements(Func<T, bool> action)
    {
        for (int i = 0; i < _size; i++)
        {
            if (!action(array[i]))
            {
                return false;
            }
        }
        return true;
    }

    public void DoToAllElements(Func<T, T> action)
    {
        for(int i = 0; i < _size; i++)
        {
            array[i] = action(array[i]);
        }
    }

    public T Minimum()
    {
        T[] newarray = new T[_size];
        for (int i = 0; i < _size; i++)
        {
            newarray[i] = array[i];
        }
        Array.Sort(newarray);
        return newarray[0];
    }

    public T Maximum()
    {
        T[] newarray = new T[_size];
        for (int i = 0; i < _size; i++)
        {
            newarray[i] = array[i];
        }
        Array.Sort(newarray);
        return newarray[_size-1];
    }

    public void Reverse()
    {
        T[] newarray = new T[_size];
        int leng = 0;
        for (int i = _size; i > 0; i--)
        {
            newarray[leng] = array[i];
            leng++;
        }
        for (int i = 0; i < _size; i++)
        {
            array[i] = newarray[i];
        }
    }

    public T[] ReturnAllAppropriate(Func<T, bool> action)
    {
        T[] newarray = new T[CountAppropriate(action)];
        int c = 0;
        for (int i = 0; i < _size; i++)
        {
            if (action(array[i]))
            {
                newarray[c] = array[i];
                c++;
            }
        }
        return newarray;
    }

    public T ReturnFirstAppropriate (Func<T, bool> action)
    {
        for (int i = 0; i < _size; i++)
        {
            if (action(array[i]))
            {
                return array[i];
            }
        }
        return default(T);
    }

    public bool DoesElementExist(T element)
    {
        if(array.Contains(element))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CountAppropriate(Func<T, bool> action)
    {
        int count = 0;
        for(int i = 0; i < _size; i++)
        {
            if(action(array[i])){
                count++;
            }
        }
        return count;
    }

}