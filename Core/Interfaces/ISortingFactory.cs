using Common.Enums;
using Common.Models;

namespace Core.Interfaces
{
    /// <summary>
    /// Overkill for this exercise, but demonstrates use of factory pattern
    /// </summary>
    public interface ISortingFactory
    {
        /// <summary>
        /// Spawn logic interface member
        /// </summary>
        /// <typeparam name="TInput">Input model for the sort</typeparam>
        /// <typeparam name="TOutput">Output model for the sort</typeparam>
        /// <param name="sortingType">Sorting Type</param>
        /// <param name="sortingSubType">Sorting sub type</param>
        /// <returns>Sorting logic instance</returns>
        ISortingLogic<TInput, TOutput> CreateSortingLogic<TInput, TOutput>(SortingType sortingType, SortingSubType sortingSubType)
            where TInput : BaseInput
            where TOutput : BaseOutput;
    }
}
