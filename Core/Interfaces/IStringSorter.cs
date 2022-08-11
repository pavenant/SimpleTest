namespace Core.Interfaces
{
    /// <summary>
    /// String sorter interace
    /// Allows us to expand the library for different sort implementations
    /// </summary>
    public interface IStringSorter : ISortingLogic<string, string>
    {        
    }
}