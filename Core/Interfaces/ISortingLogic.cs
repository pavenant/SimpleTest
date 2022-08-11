namespace Core.Interfaces
{
    /// <summary>
    /// Sorting logic interface
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface ISortingLogic<TInput, TOutput>
    {
        /// <summary>
        /// Sort interface member
        /// </summary>
        /// <param name="someInput"></param>
        /// <returns></returns>
        TOutput Sort(TInput someInput);
    }
}
