using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad01
{
    public interface IIntegerList
    {
        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        void Add(int item);

        /// <summary>
        /// Removes the first occurrence of an item from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Remove(int item);

        /// <summary>
        /// Removes the item at the given index in the collection.
        /// Throws IndexOutOfRange exception if index out of range.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool RemoveAt(int index);

        /// <summary>
        /// Returns the item at the given index in the collection.
        /// Throws IndexOutOfRange exception if index out of range.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        int GetElement(int index);

        /// <summary>
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection, method return -1.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        int indexOf(int item);

        /// <summary>
        /// Readonly property. Gets the number of item contained in the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int Count { get; }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Contains(int item);

    }
}
