using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DZ
{
    interface IIntegerList
    {
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item being added.</param>
        void Add(int item);
        /// <summary>
        /// Attempts to remove the first occurence of an item in the collection.
        /// </summary>
        /// <param name="item">The item being removed.</param>
        /// <returns>True if item is successfully removed.</returns>
        bool Remove(int item);
        /// <summary>
        /// Removes the item at the given index in the collection.
        /// </summary>
        /// <param name="index">The index of the item being removed.</param>
        /// <returns>True if the item is successfully removed.</returns>
        bool RemoveAt(int index);
        /// <summary>
        /// Retrieves the element at the provided index from the collection.
        /// </summary>
        /// <param name="index">The index of the element being retrieved.</param>
        /// <returns>Returns the element if it exists, returns -1 otherwise.</returns>
        int GetElement(int index);
        /// <summary>
        /// Returns the index of the first occurence of an item in the collection.
        /// </summary>
        /// <param name="item">The item whose index is being searched.</param>
        /// <returns>Returns the index if the element exists, returns -1 otherwise.</returns>
        int IndexOf(int item);
        /// <summary>
        /// Readonly property. Gets the number of items inside the colection.
        /// </summary>
        int Count { get;  }
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        void Clear();
        /// <summary>
        /// Determins if the collection contains a given item.
        /// </summary>
        /// <param name="item">The item whose existence has been put in question.</param>
        /// <returns>Returns true if the item exists in the collection.</returns>
        bool Contains(int item);

    }
}
