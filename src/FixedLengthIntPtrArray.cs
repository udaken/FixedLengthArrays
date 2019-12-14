//#define GENERATE_ENUMERABLE
//#define GENERATE_CTOR
#define GENERATE_ASSPAN

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace FixedLengthArray
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray2 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray2>
		, IEquatableByRef<FixedLengthIntPtrArray2>
	{
		public const int ConstLength = 2;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray2(
			IntPtr field0
			, IntPtr field1
		)
		{
			Field0 = field0;
			Field1 = field1;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray2 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray2 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray2>.Equals(FixedLengthIntPtrArray2 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray2 left, in FixedLengthIntPtrArray2 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray2 left, in FixedLengthIntPtrArray2 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray2 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray2 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray2 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray2 array1, in FixedLengthIntPtrArray2 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray2 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray2 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray2 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray2 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray2 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray2 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray3 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray3>
		, IEquatableByRef<FixedLengthIntPtrArray3>
	{
		public const int ConstLength = 3;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray3(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray3 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray3 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray3>.Equals(FixedLengthIntPtrArray3 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray3 left, in FixedLengthIntPtrArray3 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray3 left, in FixedLengthIntPtrArray3 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray3 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray3 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray3 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray3 array1, in FixedLengthIntPtrArray3 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray3 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray3 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray3 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray3 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray3 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray3 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray4 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray4>
		, IEquatableByRef<FixedLengthIntPtrArray4>
	{
		public const int ConstLength = 4;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray4(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray4 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray4 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray4>.Equals(FixedLengthIntPtrArray4 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray4 left, in FixedLengthIntPtrArray4 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray4 left, in FixedLengthIntPtrArray4 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray4 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray4 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray4 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray4 array1, in FixedLengthIntPtrArray4 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray4 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray4 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray4 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray4 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray4 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray4 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray5 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray5>
		, IEquatableByRef<FixedLengthIntPtrArray5>
	{
		public const int ConstLength = 5;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray5(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray5 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray5 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray5>.Equals(FixedLengthIntPtrArray5 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray5 left, in FixedLengthIntPtrArray5 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray5 left, in FixedLengthIntPtrArray5 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray5 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray5 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray5 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray5 array1, in FixedLengthIntPtrArray5 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray5 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray5 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray5 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray5 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray5 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray5 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray6 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray6>
		, IEquatableByRef<FixedLengthIntPtrArray6>
	{
		public const int ConstLength = 6;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray6(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
			, IntPtr field5
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
			Field5 = field5;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;
		public IntPtr Field5;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                5 => Field5,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
                    case 5: Field5 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray6 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray6 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray6>.Equals(FixedLengthIntPtrArray6 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray6 left, in FixedLengthIntPtrArray6 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray6 left, in FixedLengthIntPtrArray6 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray6 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray6 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray6 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray6 array1, in FixedLengthIntPtrArray6 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray6 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray6 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray6 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray6 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
                case 5: return ref array.Field5;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray6 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray6 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray7 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray7>
		, IEquatableByRef<FixedLengthIntPtrArray7>
	{
		public const int ConstLength = 7;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray7(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
			, IntPtr field5
			, IntPtr field6
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
			Field5 = field5;
			Field6 = field6;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;
		public IntPtr Field5;
		public IntPtr Field6;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                5 => Field5,
                6 => Field6,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
                    case 5: Field5 = value; break;
                    case 6: Field6 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray7 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray7 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray7>.Equals(FixedLengthIntPtrArray7 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray7 left, in FixedLengthIntPtrArray7 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray7 left, in FixedLengthIntPtrArray7 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray7 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray7 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray7 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray7 array1, in FixedLengthIntPtrArray7 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray7 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray7 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray7 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray7 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
                case 5: return ref array.Field5;
                case 6: return ref array.Field6;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray7 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray7 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray8 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray8>
		, IEquatableByRef<FixedLengthIntPtrArray8>
	{
		public const int ConstLength = 8;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray8(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
			, IntPtr field5
			, IntPtr field6
			, IntPtr field7
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
			Field5 = field5;
			Field6 = field6;
			Field7 = field7;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;
		public IntPtr Field5;
		public IntPtr Field6;
		public IntPtr Field7;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                5 => Field5,
                6 => Field6,
                7 => Field7,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
                    case 5: Field5 = value; break;
                    case 6: Field6 = value; break;
                    case 7: Field7 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray8 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray8 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray8>.Equals(FixedLengthIntPtrArray8 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray8 left, in FixedLengthIntPtrArray8 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray8 left, in FixedLengthIntPtrArray8 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray8 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray8 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray8 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray8 array1, in FixedLengthIntPtrArray8 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray8 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray8 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray8 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray8 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
                case 5: return ref array.Field5;
                case 6: return ref array.Field6;
                case 7: return ref array.Field7;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray8 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray8 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray16 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray16>
		, IEquatableByRef<FixedLengthIntPtrArray16>
	{
		public const int ConstLength = 16;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray16(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
			, IntPtr field5
			, IntPtr field6
			, IntPtr field7
			, IntPtr field8
			, IntPtr field9
			, IntPtr field10
			, IntPtr field11
			, IntPtr field12
			, IntPtr field13
			, IntPtr field14
			, IntPtr field15
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
			Field5 = field5;
			Field6 = field6;
			Field7 = field7;
			Field8 = field8;
			Field9 = field9;
			Field10 = field10;
			Field11 = field11;
			Field12 = field12;
			Field13 = field13;
			Field14 = field14;
			Field15 = field15;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;
		public IntPtr Field5;
		public IntPtr Field6;
		public IntPtr Field7;
		public IntPtr Field8;
		public IntPtr Field9;
		public IntPtr Field10;
		public IntPtr Field11;
		public IntPtr Field12;
		public IntPtr Field13;
		public IntPtr Field14;
		public IntPtr Field15;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                5 => Field5,
                6 => Field6,
                7 => Field7,
                8 => Field8,
                9 => Field9,
                10 => Field10,
                11 => Field11,
                12 => Field12,
                13 => Field13,
                14 => Field14,
                15 => Field15,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
                    case 5: Field5 = value; break;
                    case 6: Field6 = value; break;
                    case 7: Field7 = value; break;
                    case 8: Field8 = value; break;
                    case 9: Field9 = value; break;
                    case 10: Field10 = value; break;
                    case 11: Field11 = value; break;
                    case 12: Field12 = value; break;
                    case 13: Field13 = value; break;
                    case 14: Field14 = value; break;
                    case 15: Field15 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray16 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray16 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray16>.Equals(FixedLengthIntPtrArray16 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray16 left, in FixedLengthIntPtrArray16 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray16 left, in FixedLengthIntPtrArray16 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray16 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray16 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray16 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray16 array1, in FixedLengthIntPtrArray16 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray16 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray16 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray16 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray16 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
                case 5: return ref array.Field5;
                case 6: return ref array.Field6;
                case 7: return ref array.Field7;
                case 8: return ref array.Field8;
                case 9: return ref array.Field9;
                case 10: return ref array.Field10;
                case 11: return ref array.Field11;
                case 12: return ref array.Field12;
                case 13: return ref array.Field13;
                case 14: return ref array.Field14;
                case 15: return ref array.Field15;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray16 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray16 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FixedLengthIntPtrArray32 : IFixedLengthArray<IntPtr>
		, IEquatable<FixedLengthIntPtrArray32>
		, IEquatableByRef<FixedLengthIntPtrArray32>
	{
		public const int ConstLength = 32;
		public readonly int Length => ConstLength;
		readonly int IReadOnlyCollection<IntPtr>.Count => ConstLength;

#if GENERATE_CTOR
		public FixedLengthIntPtrArray32(
			IntPtr field0
			, IntPtr field1
			, IntPtr field2
			, IntPtr field3
			, IntPtr field4
			, IntPtr field5
			, IntPtr field6
			, IntPtr field7
			, IntPtr field8
			, IntPtr field9
			, IntPtr field10
			, IntPtr field11
			, IntPtr field12
			, IntPtr field13
			, IntPtr field14
			, IntPtr field15
			, IntPtr field16
			, IntPtr field17
			, IntPtr field18
			, IntPtr field19
			, IntPtr field20
			, IntPtr field21
			, IntPtr field22
			, IntPtr field23
			, IntPtr field24
			, IntPtr field25
			, IntPtr field26
			, IntPtr field27
			, IntPtr field28
			, IntPtr field29
			, IntPtr field30
			, IntPtr field31
		)
		{
			Field0 = field0;
			Field1 = field1;
			Field2 = field2;
			Field3 = field3;
			Field4 = field4;
			Field5 = field5;
			Field6 = field6;
			Field7 = field7;
			Field8 = field8;
			Field9 = field9;
			Field10 = field10;
			Field11 = field11;
			Field12 = field12;
			Field13 = field13;
			Field14 = field14;
			Field15 = field15;
			Field16 = field16;
			Field17 = field17;
			Field18 = field18;
			Field19 = field19;
			Field20 = field20;
			Field21 = field21;
			Field22 = field22;
			Field23 = field23;
			Field24 = field24;
			Field25 = field25;
			Field26 = field26;
			Field27 = field27;
			Field28 = field28;
			Field29 = field29;
			Field30 = field30;
			Field31 = field31;
		}
#endif

		public IntPtr Field0;
		public IntPtr Field1;
		public IntPtr Field2;
		public IntPtr Field3;
		public IntPtr Field4;
		public IntPtr Field5;
		public IntPtr Field6;
		public IntPtr Field7;
		public IntPtr Field8;
		public IntPtr Field9;
		public IntPtr Field10;
		public IntPtr Field11;
		public IntPtr Field12;
		public IntPtr Field13;
		public IntPtr Field14;
		public IntPtr Field15;
		public IntPtr Field16;
		public IntPtr Field17;
		public IntPtr Field18;
		public IntPtr Field19;
		public IntPtr Field20;
		public IntPtr Field21;
		public IntPtr Field22;
		public IntPtr Field23;
		public IntPtr Field24;
		public IntPtr Field25;
		public IntPtr Field26;
		public IntPtr Field27;
		public IntPtr Field28;
		public IntPtr Field29;
		public IntPtr Field30;
		public IntPtr Field31;

        public IntPtr this[int index]
        {
#if GENERATE_ASSPAN
			readonly get => FixedLengthArrayExtension.AsReadOnlySpan(in this)[index];
			set => FixedLengthArrayExtension.AsSpan(ref this)[index] = value;
#else
            readonly get => index switch
            {
                0 => Field0,
                1 => Field1,
                2 => Field2,
                3 => Field3,
                4 => Field4,
                5 => Field5,
                6 => Field6,
                7 => Field7,
                8 => Field8,
                9 => Field9,
                10 => Field10,
                11 => Field11,
                12 => Field12,
                13 => Field13,
                14 => Field14,
                15 => Field15,
                16 => Field16,
                17 => Field17,
                18 => Field18,
                19 => Field19,
                20 => Field20,
                21 => Field21,
                22 => Field22,
                23 => Field23,
                24 => Field24,
                25 => Field25,
                26 => Field26,
                27 => Field27,
                28 => Field28,
                29 => Field29,
                30 => Field30,
                31 => Field31,
                _ => throw new ArgumentOutOfRangeException(nameof(index)),
            };
            set
            {
                switch (index)
                {
                    case 0: Field0 = value; break;
                    case 1: Field1 = value; break;
                    case 2: Field2 = value; break;
                    case 3: Field3 = value; break;
                    case 4: Field4 = value; break;
                    case 5: Field5 = value; break;
                    case 6: Field6 = value; break;
                    case 7: Field7 = value; break;
                    case 8: Field8 = value; break;
                    case 9: Field9 = value; break;
                    case 10: Field10 = value; break;
                    case 11: Field11 = value; break;
                    case 12: Field12 = value; break;
                    case 13: Field13 = value; break;
                    case 14: Field14 = value; break;
                    case 15: Field15 = value; break;
                    case 16: Field16 = value; break;
                    case 17: Field17 = value; break;
                    case 18: Field18 = value; break;
                    case 19: Field19 = value; break;
                    case 20: Field20 = value; break;
                    case 21: Field21 = value; break;
                    case 22: Field22 = value; break;
                    case 23: Field23 = value; break;
                    case 24: Field24 = value; break;
                    case 25: Field25 = value; break;
                    case 26: Field26 = value; break;
                    case 27: Field27 = value; break;
                    case 28: Field28 = value; break;
                    case 29: Field29 = value; break;
                    case 30: Field30 = value; break;
                    case 31: Field31 = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
#endif
        }
#if GENERATE_ASSPAN
        public readonly override bool Equals(object other)
			=> other is FixedLengthIntPtrArray32 array
				? FixedLengthArrayExtension.Equals(in this, array)
				: false;

        public readonly bool Equals(in FixedLengthIntPtrArray32 other)
			=> FixedLengthArrayExtension.Equals(in this, in other);

        readonly bool IEquatable<FixedLengthIntPtrArray32>.Equals(FixedLengthIntPtrArray32 other)
			=> this.Equals(in other);
		
        public static bool operator ==(in FixedLengthIntPtrArray32 left, in FixedLengthIntPtrArray32 right)
            => left.Equals(right);

        public static bool operator !=(in FixedLengthIntPtrArray32 left, in FixedLengthIntPtrArray32 right)
            => !(left == right);
#endif

        public override readonly int GetHashCode()
        {
#if GENERATE_ASSPAN
			int hash = 0;
			var span = FixedLengthArrayExtension.AsReadOnlySpan(this);
            for(int i = 0; i < span.Length; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)span[i].GetHashCode(), i));
			}
			return hash;
#else
			int hash = 0;
            for(int i = 0; i < ConstLength; i++)
			{
				hash = FixedLengthArray.Combine(hash, (int)FixedLengthArray.RotateToLeft((uint)this[i].GetHashCode(), i));
			}
			return hash;
#endif
        }

		readonly IEnumerator<IntPtr> IEnumerable<IntPtr>.GetEnumerator()
		{
			for(var i = 0; i < ConstLength; i++)
			{
				yield return this[i];
			}
		}

		readonly System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> (this as IEnumerable<IntPtr>).GetEnumerator();

#if GENERATE_ASSPAN
		public readonly ReadOnlySpan<IntPtr>.Enumerator GetEnumerator()
			=> FixedLengthArrayExtension.AsReadOnlySpan(this).GetEnumerator();

        public static implicit operator ReadOnlySpan<IntPtr>(in FixedLengthIntPtrArray32 self)
            => self.AsReadOnlySpan();
#endif
	}
	
    public static partial class FixedLengthArrayExtension
    {
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static Span<IntPtr> AsSpan(this ref FixedLengthIntPtrArray32 array)
            => FixedLengthArray.CreateSpan(ref array.Field0, array.Length);

		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<IntPtr> AsReadOnlySpan(this in FixedLengthIntPtrArray32 array)
            => FixedLengthArray.CreateReadOnlySpan(array.Field0, array.Length);
#endif

        public static bool Equals(in FixedLengthIntPtrArray32 array1, in FixedLengthIntPtrArray32 array2)
		{
			for(int i = 0; i < array1.Length;i++ )
			{
				if(array1[i] != array2[i])
					return false;
			}
			return true;
		}
#if GENERATE_ASSPAN
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static ref IntPtr At(this ref FixedLengthIntPtrArray32 array, int index)
            => ref AsSpan(ref array)[index];

        public static void CopyTo(this in FixedLengthIntPtrArray32 array, Span<IntPtr> destination)
            => AsReadOnlySpan(array).CopyTo(destination);

        public static void Fill(this ref FixedLengthIntPtrArray32 array, IntPtr value = default)
            => AsSpan(ref array).Fill(value);
#else
        public static ref IntPtr At(this ref FixedLengthIntPtrArray32 array, int index)
        {
            switch (index)
            {
                case 0: return ref array.Field0;
                case 1: return ref array.Field1;
                case 2: return ref array.Field2;
                case 3: return ref array.Field3;
                case 4: return ref array.Field4;
                case 5: return ref array.Field5;
                case 6: return ref array.Field6;
                case 7: return ref array.Field7;
                case 8: return ref array.Field8;
                case 9: return ref array.Field9;
                case 10: return ref array.Field10;
                case 11: return ref array.Field11;
                case 12: return ref array.Field12;
                case 13: return ref array.Field13;
                case 14: return ref array.Field14;
                case 15: return ref array.Field15;
                case 16: return ref array.Field16;
                case 17: return ref array.Field17;
                case 18: return ref array.Field18;
                case 19: return ref array.Field19;
                case 20: return ref array.Field20;
                case 21: return ref array.Field21;
                case 22: return ref array.Field22;
                case 23: return ref array.Field23;
                case 24: return ref array.Field24;
                case 25: return ref array.Field25;
                case 26: return ref array.Field26;
                case 27: return ref array.Field27;
                case 28: return ref array.Field28;
                case 29: return ref array.Field29;
                case 30: return ref array.Field30;
                case 31: return ref array.Field31;
				default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
        public static void CopyTo(this in FixedLengthIntPtrArray32 array, IntPtr[] dest, int offset = 0)
        {
            for(int i = 0; i < array.Length;i++ )
			{
				dest[offset + i] = array[i];
			}
        }
        public static void Fill(this ref FixedLengthIntPtrArray32 array, IntPtr value = default)
        {
			for(int i = 0; i < array.Length;i++ )
			{
				array[i] = value;
			}
        }
#endif
    }
}
