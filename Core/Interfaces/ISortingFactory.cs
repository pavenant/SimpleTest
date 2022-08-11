using Common.Enums;
using Common.Models;

namespace Core.Interfaces
{
    /// <summary>
    /// Overkill for this exercise, but demonstrates use of factory pattern
    /// </summary>
    public interface ISortingFactory
    {
        ISortingLogic<TInput, TOutput> CreateSortingLogic<TInput, TOutput>(SortingType sortingType, SortingSubType sortingSubType)
            where TInput : BaseInput
            where TOutput : BaseOutput;
    }
}
