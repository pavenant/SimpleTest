namespace Core.Interfaces
{
    public interface ISortingLogic<TInput, TOutput>
    {
        TOutput Sort(TInput someInput);
    }
}
