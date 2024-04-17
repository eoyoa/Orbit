namespace Library
{
    public interface IAdjacencyFunction<T>
    {
        bool CheckAdjacent(T v, T w);
    }
}