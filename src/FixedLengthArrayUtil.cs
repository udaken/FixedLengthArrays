using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FixedLengthArray
{
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
