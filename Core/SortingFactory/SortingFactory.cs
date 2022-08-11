using Common.Enums;
using Core.Interfaces;
using Common.Models;
using Core.SortingLogic;

namespace Core.SortingFactory
{
    public class SortingFactory : ISortingFactory
    {
        public ISortingLogic<TInput, TOutput> CreateSortingLogic<TInput, TOutput>(SortingType sortingType, SortingSubType sortingSubType)
            where TInput : BaseInput
            where TOutput : BaseOutput
        {
            switch (sortingType)
            {
                case SortingType.StringSort:
                    switch (sortingSubType)
                    {
                        case SortingSubType.TextABCSort:
                            return (ISortingLogic<TInput, TOutput>) new TextABCSort();

                        case SortingSubType.NumericASCSort:
                        default:
                            throw new NotImplementedException($"Sorting sub type {sortingSubType} is not currently supported.");
                    }

                case SortingType.NumericSort:
                default: 
                    throw new NotImplementedException($"Sorting type {sortingType} is not currently supported.");
            }
        }
    }
}
