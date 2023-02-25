using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRTranslatorGUI
{
    static class Extensions
    {
        public static T[] AddElementsToArray<T>(T[] originalArray, params T[] newElements)
        {
            int originalLength = originalArray.Length;
            int newLength = originalLength + newElements.Length;
            T[] newArray = new T[newLength];

            Array.Copy(originalArray, newArray, originalLength);
            Array.Copy(newElements, 0, newArray, originalLength, newElements.Length);

            return newArray;
        }
    }
}
