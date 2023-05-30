public class Program {
    static {
        System.load("/Users/kate/Desktop/TechProg/lab-1/task1/Java/src/library.dylib");
    }

    public static void main(String[] args) {
        System.out.println(new Program().add(5,4));
    }

    public native int add(int a, int b);
}
