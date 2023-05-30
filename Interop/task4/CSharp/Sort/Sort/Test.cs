namespace Sort;

public class Test
{
    static void Swap(ref int e1, ref int e2)
    {
        (e1, e2) = (e2, e1);
    }
    static int[] BubbleSort(int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    }

    static void Merge(int[] numbers, int left, int mid, int right)    
    {    
        int[] temp = new int[25];    
        int i, eol, num, pos;    
        eol = (mid - 1);    
        pos = left;   
        num = (right - left + 1);     
  
        while ((left <= eol) && (mid <= right))    
        {    
            if (numbers[left] <= numbers[mid])    
                temp[pos++] = numbers[left++];    
            else    
                temp[pos++] = numbers[mid++];    
        }    
        while (left <= eol)    
            temp[pos++] = numbers[left++];    
        while (mid <= right)    
            temp[pos++] = numbers[mid++];   
        for (i = 0; i < num; i++)    
        {    
            numbers[right] = temp[right];    
            right--;    
        }    
    }   
  
    static int[] SortMerge(int[] numbers, int left, int right)    
    {    
        int mid;    
        if (right > left)    
        {    
            mid = (right + left) / 2;    
            SortMerge(numbers, left, mid);    
            SortMerge(numbers, (mid + 1), right);    
            Merge(numbers, left, (mid + 1), right);    
        }

        return numbers;
    }
    static int[] MergeSort(int[] array)
    {
        return SortMerge(array, 0, array.Length - 1);
    }

}