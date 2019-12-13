using System;
using System.Collections.Generic;

namespace FixedLengthArray
{
    public interface IFixedLengthArray<T> : IReadOnlyList<T>
        where T : struct
    {
        int Length { get; }
        new T this[int index] { set; get; }
    }
    public interface IEquatableByRef<T> where T : struct
    {
        bool Equals(in T other);
    }
}
