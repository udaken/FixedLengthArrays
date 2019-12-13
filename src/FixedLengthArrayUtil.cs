using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace FixedLengthArray
{
    public static partial class FixedLengthArrayExtension
    {
        public static T[] ToArray<T, TArray>(ref this TArray array)
            where T : struct
            where TArray : struct, IFixedLengthArray<T>
        {
            var arr = new T[array.Length];
            CopyTo(ref array, arr);
            return arr;
        }
        public static void CopyTo<T, TArray>(ref this TArray array, T[] dest, int offset = 0)
            where T : struct
            where TArray : struct, IFixedLengthArray<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                dest[offset + i] = array[i];
            }
        }
    }

    internal static class FixedLengthArray
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint RotateToLeft(uint value, int shift)
            => (value >> ((~shift) >> 1)) | (value << shift);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Combine(int h1, int h2)
            => ((int)RotateToLeft((uint)h1, 5) + h1) ^ h2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe ReadOnlySpan<T> CreateReadOnlySpan<T>(in T unmanaged, int length) where T : unmanaged
            => new ReadOnlySpan<T>(Unsafe.AsPointer(ref Unsafe.AsRef(in unmanaged)), length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe Span<T> CreateSpan<T>(ref T unmanaged, int length) where T : unmanaged
            => new Span<T>(Unsafe.AsPointer(ref unmanaged), length);
    }
}
