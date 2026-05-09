public static class Quicksorter
{
    // Public entry: returns a new sorted copy using recursive quicksort
    public static double[] Sort(double[] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        var copy = (double[])input.Clone();
        if (copy.Length <= 1) return copy;
        Quicksort(copy, 0, copy.Length - 1);
        return copy;
    }

    static void Quicksort(double[] a, int low, int high)
    {
        if (low < high)
        {
            int p = Partition(a, low, high);
            Quicksort(a, low, p - 1);
            Quicksort(a, p + 1, high);
        }
    }

    // Lomuto partition scheme
    static int Partition(double[] a, int low, int high)
    {
        double pivot = a[high];
        int i = low;
        for (int j = low; j < high; j++)
        {
            if (a[j] <= pivot)
            {
                Swap(a, i, j);
                i++;
            }
        }
        Swap(a, i, high);
        return i;
    }

    static void Swap(double[] a, int i, int j)
    {
        if (i == j) return;
        double t = a[i];
        a[i] = a[j];
        a[j] = t;
    }
}
