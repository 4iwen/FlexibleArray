namespace FlexibleArray;

public class FlexibleArray<T>
{
    private T[] _data;

    public int Length => _data.Length;

    public FlexibleArray(T[] data)
    {
        _data = data;
    }
    
    public FlexibleArray(int size)
    {
        _data = new T[size];
    }

    public void InsertAt(int index, T value)
    {
        if (index > _data.Length)
            throw new IndexOutOfRangeException("Index greater than array length");
        
        T[] temp = new T[_data.Length + 1];
        
        for (int i = 0; i < index; i++)
        {
            temp[i] = _data[i];
        }
        
        temp[index] = value;
        
        for (int i = index + 1; i < temp.Length; i++)
        {
            temp[i] = _data[i - 1];
        }
        
        _data = temp;
    }

    public void RemoveAt(int index)
    {
        if (index >= _data.Length)
            throw new IndexOutOfRangeException("Index greater than array length");
        
        T[] temp = new T[_data.Length - 1];
        
        for (int i = 0; i < index; i++)
        {
            temp[i] = _data[i];
        }

        for (int i = index; i < _data.Length - 1; i++)
        {
            temp[i] = _data[i + 1];
        }
        
        _data = temp;
    }
    
    public void Join(FlexibleArray<T> other)
    {
        T[] temp = new T[_data.Length + other._data.Length];
        
        uint i = 0;
        uint j = 0;
        uint k = 0;
        
        while (i < _data.Length && j < other._data.Length)
        {
            temp[k++] = _data[i++];
            temp[k++] = other._data[j++];
        }
        
        while (i < _data.Length)
        {
            temp[k++] = _data[i++];
        }
        
        while (j < other._data.Length)
        {
            temp[k++] = other._data[j++];
        }
        
        _data = temp;
    }

    public void SplitByOddEvenIndex(out FlexibleArray<T> even, out FlexibleArray<T> odd)
    {
        even = new FlexibleArray<T>(_data.Length / 2 + _data.Length % 2);
        odd = new FlexibleArray<T>(_data.Length / 2);

        for (int i = 0; i < _data.Length; i++)
        {
            if (i % 2 == 0)
            {
                even[i / 2] = _data[i];
            }
            else
            {
                odd[i / 2] = _data[i];
            }
        }
    }
    
    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }

    public override string ToString()
    {
        return $"Type: [{typeof(T)}],\nLength: [{_data.Length}],\nData: [{String.Join(", ", _data)}]\n";
    }
}