namespace Core.Interfaces
{
    /// <summary>
    /// String sorter interace
    /// Allows us to expand the library for different sort implementations
    /// </summary>
    public interface IStringSorter
    {
        /// <summary>
        /// Sort string input
        /// </summary>
        /// <param name="stringInput">String to be sorted</param>
        /// <returns>Sorted string output</returns>
        string SortString(string stringInput);
    }
}