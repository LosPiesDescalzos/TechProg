package benchmark;

import org.openjdk.jmh.annotations.*;
import java.util.*;
import java.util.concurrent.TimeUnit;

@State(Scope.Benchmark)
public class Tests {

        private static Random random = new Random();

        @Param({"100", "10000"})
        private static int arraySize;
        public int [] array;

        @Setup(Level.Invocation)
        public void setUp() {
                array = random.ints(arraySize).toArray();
        }

        @Benchmark
        @Fork(value = 1)
        @Warmup(iterations = 1)
        @BenchmarkMode(Mode.AverageTime)
        @OutputTimeUnit(TimeUnit.NANOSECONDS)
        public void BenchmarkBubbleSort() {
                bubbleSort(array);
        }

        @Benchmark
        @Fork(value = 1)
        @Warmup(iterations = 1)
        @BenchmarkMode(Mode.AverageTime)
        @OutputTimeUnit(TimeUnit.NANOSECONDS)
        public void BenchmarkMargeSort() {
                mergeSort(array, arraySize);
        }

        @Benchmark
        @Fork(value = 1)
        @Warmup(iterations = 1)
        @BenchmarkMode(Mode.AverageTime)
        @OutputTimeUnit(TimeUnit.NANOSECONDS)
        public void BenchmarkStandartSort() {
                Arrays.sort(array);
        }

        public static void bubbleSort(int[] array) {
                boolean sorted = false;
                int temp;
                while(!sorted) {
                        sorted = true;
                        for (int i = 0; i < array.length - 1; i++) {
                                if (array[i] > array[i+1]) {
                                        temp = array[i];
                                        array[i] = array[i+1];
                                        array[i+1] = temp;
                                        sorted = false;
                                }
                        }
                }
        }
        public static void merge(
                int[] a, int[] l, int[] r, int left, int right) {

                int i = 0, j = 0, k = 0;
                while (i < left && j < right) {
                        if (l[i] <= r[j]) {
                                a[k++] = l[i++];
                        }
                        else {
                                a[k++] = r[j++];
                        }
                }
                while (i < left) {
                        a[k++] = l[i++];
                }
                while (j < right) {
                        a[k++] = r[j++];
                }
        }

        public static void mergeSort(int[] a, int n) {
                if (n < 2) {
                        return;
                }
                int mid = n / 2;
                int[] l = new int[mid];
                int[] r = new int[n - mid];

                for (int i = 0; i < mid; i++) {
                        l[i] = a[i];
                }
                for (int i = mid; i < n; i++) {
                        r[i - mid] = a[i];
                }
                mergeSort(l, mid);
                mergeSort(r, n - mid);

                merge(a, l, r, mid, n - mid);
        }
}
