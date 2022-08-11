﻿using Common.Enums;
using Core.Interfaces;
using Common.Models;
using Core.SortingLogic;

namespace Core.SortingFactory
{
    /// <summary>
    /// Sorting factory
    /// </summary>
    public class SortingFactory : ISortingFactory
    {
        /// <summary>
        /// Spawn logic implementation based on sorting type, and sub type
        /// </summary>
        /// <typeparam name="TInput">Input model for the sort</typeparam>
        /// <typeparam name="TOutput">Output model for the sort</typeparam>
        /// <param name="sortingType">Sorting Type</param>
        /// <param name="sortingSubType">Sorting sub type</param>
        /// <returns>Sorting logic instance</returns>
        /// <exception cref="NotImplementedException">Not all sorts are completed</exception>
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
