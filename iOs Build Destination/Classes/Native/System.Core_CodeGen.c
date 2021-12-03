#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000005 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000006 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000007 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000008 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x00000009 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000A TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000B System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000C TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000E TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000000F System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000010 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000011 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000012 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000013 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000014 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000015 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000016 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000017 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x00000018 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x00000019 System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x0000001A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000001B System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000001C System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x0000001D System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000001E System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x0000001F System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000020 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000021 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000022 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000023 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000024 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000025 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000026 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000027 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x00000028 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000029 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002A System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000002B System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x0000002C System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x0000002D System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002E System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002F System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000030 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000031 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000032 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000033 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000034 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000035 System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000036 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000037 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x00000038 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000039 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003A System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003B System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x0000003C System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x0000003D System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003E System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003F System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000040 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000041 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000042 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000043 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000044 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x00000045 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000046 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000047 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000048 System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x00000049 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x0000004A System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x0000004B System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x0000004C TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x0000004D System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x0000004E System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x0000004F System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000050 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000051 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000052 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000053 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x00000054 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x00000055 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x00000056 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000057 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x00000058 System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x00000059 System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x0000005A TElement[] System.Linq.Buffer`1::ToArray()
// 0x0000005B System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x0000005C System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x0000005D System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000005E System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x0000005F System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000060 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x00000061 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x00000062 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x00000063 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x00000064 System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x00000065 System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x00000066 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000067 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000068 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000069 System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x0000006A System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x0000006B System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x0000006C System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x0000006D System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x0000006E System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x0000006F System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000070 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x00000071 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x00000072 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x00000073 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x00000074 System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x00000075 T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x00000076 System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000077 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[119] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[119] = 
{
	2374,
	2458,
	2458,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[40] = 
{
	{ 0x02000004, { 62, 4 } },
	{ 0x02000005, { 66, 9 } },
	{ 0x02000006, { 77, 7 } },
	{ 0x02000007, { 86, 10 } },
	{ 0x02000008, { 98, 11 } },
	{ 0x02000009, { 112, 9 } },
	{ 0x0200000A, { 124, 12 } },
	{ 0x0200000B, { 139, 1 } },
	{ 0x0200000C, { 140, 2 } },
	{ 0x0200000E, { 142, 3 } },
	{ 0x0200000F, { 147, 5 } },
	{ 0x02000010, { 152, 7 } },
	{ 0x02000011, { 159, 3 } },
	{ 0x02000012, { 162, 7 } },
	{ 0x02000013, { 169, 4 } },
	{ 0x02000014, { 173, 21 } },
	{ 0x02000016, { 194, 2 } },
	{ 0x06000004, { 0, 10 } },
	{ 0x06000005, { 10, 10 } },
	{ 0x06000006, { 20, 5 } },
	{ 0x06000007, { 25, 5 } },
	{ 0x06000008, { 30, 2 } },
	{ 0x06000009, { 32, 1 } },
	{ 0x0600000A, { 33, 3 } },
	{ 0x0600000B, { 36, 2 } },
	{ 0x0600000C, { 38, 4 } },
	{ 0x0600000D, { 42, 4 } },
	{ 0x0600000E, { 46, 3 } },
	{ 0x0600000F, { 49, 1 } },
	{ 0x06000010, { 50, 3 } },
	{ 0x06000011, { 53, 2 } },
	{ 0x06000012, { 55, 2 } },
	{ 0x06000013, { 57, 5 } },
	{ 0x06000023, { 75, 2 } },
	{ 0x06000028, { 84, 2 } },
	{ 0x0600002D, { 96, 2 } },
	{ 0x06000033, { 109, 3 } },
	{ 0x06000038, { 121, 3 } },
	{ 0x0600003D, { 136, 3 } },
	{ 0x06000047, { 145, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[196] = 
{
	{ (Il2CppRGCTXDataType)2, 1233 },
	{ (Il2CppRGCTXDataType)3, 4384 },
	{ (Il2CppRGCTXDataType)2, 2057 },
	{ (Il2CppRGCTXDataType)2, 1743 },
	{ (Il2CppRGCTXDataType)3, 7543 },
	{ (Il2CppRGCTXDataType)2, 1314 },
	{ (Il2CppRGCTXDataType)2, 1750 },
	{ (Il2CppRGCTXDataType)3, 7568 },
	{ (Il2CppRGCTXDataType)2, 1745 },
	{ (Il2CppRGCTXDataType)3, 7551 },
	{ (Il2CppRGCTXDataType)2, 1234 },
	{ (Il2CppRGCTXDataType)3, 4385 },
	{ (Il2CppRGCTXDataType)2, 2078 },
	{ (Il2CppRGCTXDataType)2, 1752 },
	{ (Il2CppRGCTXDataType)3, 7576 },
	{ (Il2CppRGCTXDataType)2, 1331 },
	{ (Il2CppRGCTXDataType)2, 1760 },
	{ (Il2CppRGCTXDataType)3, 7615 },
	{ (Il2CppRGCTXDataType)2, 1756 },
	{ (Il2CppRGCTXDataType)3, 7594 },
	{ (Il2CppRGCTXDataType)2, 430 },
	{ (Il2CppRGCTXDataType)3, 19 },
	{ (Il2CppRGCTXDataType)3, 20 },
	{ (Il2CppRGCTXDataType)2, 787 },
	{ (Il2CppRGCTXDataType)3, 3205 },
	{ (Il2CppRGCTXDataType)2, 431 },
	{ (Il2CppRGCTXDataType)3, 25 },
	{ (Il2CppRGCTXDataType)3, 26 },
	{ (Il2CppRGCTXDataType)2, 793 },
	{ (Il2CppRGCTXDataType)3, 3207 },
	{ (Il2CppRGCTXDataType)2, 1553 },
	{ (Il2CppRGCTXDataType)3, 6566 },
	{ (Il2CppRGCTXDataType)3, 3556 },
	{ (Il2CppRGCTXDataType)2, 489 },
	{ (Il2CppRGCTXDataType)3, 461 },
	{ (Il2CppRGCTXDataType)3, 462 },
	{ (Il2CppRGCTXDataType)2, 1315 },
	{ (Il2CppRGCTXDataType)3, 4853 },
	{ (Il2CppRGCTXDataType)2, 1174 },
	{ (Il2CppRGCTXDataType)2, 891 },
	{ (Il2CppRGCTXDataType)2, 974 },
	{ (Il2CppRGCTXDataType)2, 1040 },
	{ (Il2CppRGCTXDataType)2, 1175 },
	{ (Il2CppRGCTXDataType)2, 892 },
	{ (Il2CppRGCTXDataType)2, 975 },
	{ (Il2CppRGCTXDataType)2, 1041 },
	{ (Il2CppRGCTXDataType)2, 976 },
	{ (Il2CppRGCTXDataType)2, 1042 },
	{ (Il2CppRGCTXDataType)3, 3206 },
	{ (Il2CppRGCTXDataType)2, 967 },
	{ (Il2CppRGCTXDataType)2, 968 },
	{ (Il2CppRGCTXDataType)2, 1038 },
	{ (Il2CppRGCTXDataType)3, 3204 },
	{ (Il2CppRGCTXDataType)2, 890 },
	{ (Il2CppRGCTXDataType)2, 973 },
	{ (Il2CppRGCTXDataType)2, 889 },
	{ (Il2CppRGCTXDataType)3, 9103 },
	{ (Il2CppRGCTXDataType)3, 2852 },
	{ (Il2CppRGCTXDataType)2, 701 },
	{ (Il2CppRGCTXDataType)2, 970 },
	{ (Il2CppRGCTXDataType)2, 1039 },
	{ (Il2CppRGCTXDataType)2, 1089 },
	{ (Il2CppRGCTXDataType)3, 4386 },
	{ (Il2CppRGCTXDataType)3, 4388 },
	{ (Il2CppRGCTXDataType)2, 301 },
	{ (Il2CppRGCTXDataType)3, 4387 },
	{ (Il2CppRGCTXDataType)3, 4396 },
	{ (Il2CppRGCTXDataType)2, 1237 },
	{ (Il2CppRGCTXDataType)2, 1746 },
	{ (Il2CppRGCTXDataType)3, 7552 },
	{ (Il2CppRGCTXDataType)3, 4397 },
	{ (Il2CppRGCTXDataType)2, 1008 },
	{ (Il2CppRGCTXDataType)2, 1060 },
	{ (Il2CppRGCTXDataType)3, 3213 },
	{ (Il2CppRGCTXDataType)3, 9092 },
	{ (Il2CppRGCTXDataType)2, 1757 },
	{ (Il2CppRGCTXDataType)3, 7595 },
	{ (Il2CppRGCTXDataType)3, 4389 },
	{ (Il2CppRGCTXDataType)2, 1236 },
	{ (Il2CppRGCTXDataType)2, 1744 },
	{ (Il2CppRGCTXDataType)3, 7544 },
	{ (Il2CppRGCTXDataType)3, 3212 },
	{ (Il2CppRGCTXDataType)3, 4390 },
	{ (Il2CppRGCTXDataType)3, 9091 },
	{ (Il2CppRGCTXDataType)2, 1753 },
	{ (Il2CppRGCTXDataType)3, 7577 },
	{ (Il2CppRGCTXDataType)3, 4403 },
	{ (Il2CppRGCTXDataType)2, 1238 },
	{ (Il2CppRGCTXDataType)2, 1751 },
	{ (Il2CppRGCTXDataType)3, 7569 },
	{ (Il2CppRGCTXDataType)3, 4894 },
	{ (Il2CppRGCTXDataType)3, 2323 },
	{ (Il2CppRGCTXDataType)3, 3214 },
	{ (Il2CppRGCTXDataType)3, 2322 },
	{ (Il2CppRGCTXDataType)3, 4404 },
	{ (Il2CppRGCTXDataType)3, 9093 },
	{ (Il2CppRGCTXDataType)2, 1761 },
	{ (Il2CppRGCTXDataType)3, 7616 },
	{ (Il2CppRGCTXDataType)3, 4417 },
	{ (Il2CppRGCTXDataType)2, 1240 },
	{ (Il2CppRGCTXDataType)2, 1759 },
	{ (Il2CppRGCTXDataType)3, 7597 },
	{ (Il2CppRGCTXDataType)3, 4418 },
	{ (Il2CppRGCTXDataType)2, 1011 },
	{ (Il2CppRGCTXDataType)2, 1063 },
	{ (Il2CppRGCTXDataType)3, 3218 },
	{ (Il2CppRGCTXDataType)3, 3217 },
	{ (Il2CppRGCTXDataType)2, 1748 },
	{ (Il2CppRGCTXDataType)3, 7554 },
	{ (Il2CppRGCTXDataType)3, 9097 },
	{ (Il2CppRGCTXDataType)2, 1758 },
	{ (Il2CppRGCTXDataType)3, 7596 },
	{ (Il2CppRGCTXDataType)3, 4410 },
	{ (Il2CppRGCTXDataType)2, 1239 },
	{ (Il2CppRGCTXDataType)2, 1755 },
	{ (Il2CppRGCTXDataType)3, 7579 },
	{ (Il2CppRGCTXDataType)3, 3216 },
	{ (Il2CppRGCTXDataType)3, 3215 },
	{ (Il2CppRGCTXDataType)3, 4411 },
	{ (Il2CppRGCTXDataType)2, 1747 },
	{ (Il2CppRGCTXDataType)3, 7553 },
	{ (Il2CppRGCTXDataType)3, 9096 },
	{ (Il2CppRGCTXDataType)2, 1754 },
	{ (Il2CppRGCTXDataType)3, 7578 },
	{ (Il2CppRGCTXDataType)3, 4424 },
	{ (Il2CppRGCTXDataType)2, 1241 },
	{ (Il2CppRGCTXDataType)2, 1763 },
	{ (Il2CppRGCTXDataType)3, 7618 },
	{ (Il2CppRGCTXDataType)3, 4895 },
	{ (Il2CppRGCTXDataType)3, 2325 },
	{ (Il2CppRGCTXDataType)3, 3220 },
	{ (Il2CppRGCTXDataType)3, 3219 },
	{ (Il2CppRGCTXDataType)3, 2324 },
	{ (Il2CppRGCTXDataType)3, 4425 },
	{ (Il2CppRGCTXDataType)2, 1749 },
	{ (Il2CppRGCTXDataType)3, 7555 },
	{ (Il2CppRGCTXDataType)3, 9098 },
	{ (Il2CppRGCTXDataType)2, 1762 },
	{ (Il2CppRGCTXDataType)3, 7617 },
	{ (Il2CppRGCTXDataType)3, 3210 },
	{ (Il2CppRGCTXDataType)3, 3211 },
	{ (Il2CppRGCTXDataType)3, 3221 },
	{ (Il2CppRGCTXDataType)2, 432 },
	{ (Il2CppRGCTXDataType)3, 31 },
	{ (Il2CppRGCTXDataType)3, 6553 },
	{ (Il2CppRGCTXDataType)2, 1554 },
	{ (Il2CppRGCTXDataType)3, 6567 },
	{ (Il2CppRGCTXDataType)2, 490 },
	{ (Il2CppRGCTXDataType)3, 463 },
	{ (Il2CppRGCTXDataType)3, 6559 },
	{ (Il2CppRGCTXDataType)3, 2304 },
	{ (Il2CppRGCTXDataType)2, 320 },
	{ (Il2CppRGCTXDataType)3, 6554 },
	{ (Il2CppRGCTXDataType)2, 1550 },
	{ (Il2CppRGCTXDataType)3, 491 },
	{ (Il2CppRGCTXDataType)2, 502 },
	{ (Il2CppRGCTXDataType)2, 687 },
	{ (Il2CppRGCTXDataType)3, 2310 },
	{ (Il2CppRGCTXDataType)3, 6555 },
	{ (Il2CppRGCTXDataType)3, 2299 },
	{ (Il2CppRGCTXDataType)3, 2300 },
	{ (Il2CppRGCTXDataType)3, 2298 },
	{ (Il2CppRGCTXDataType)3, 2301 },
	{ (Il2CppRGCTXDataType)2, 683 },
	{ (Il2CppRGCTXDataType)2, 2118 },
	{ (Il2CppRGCTXDataType)3, 3209 },
	{ (Il2CppRGCTXDataType)3, 2303 },
	{ (Il2CppRGCTXDataType)2, 954 },
	{ (Il2CppRGCTXDataType)3, 2302 },
	{ (Il2CppRGCTXDataType)2, 893 },
	{ (Il2CppRGCTXDataType)2, 2081 },
	{ (Il2CppRGCTXDataType)2, 987 },
	{ (Il2CppRGCTXDataType)2, 1043 },
	{ (Il2CppRGCTXDataType)3, 2868 },
	{ (Il2CppRGCTXDataType)2, 709 },
	{ (Il2CppRGCTXDataType)3, 3438 },
	{ (Il2CppRGCTXDataType)3, 3439 },
	{ (Il2CppRGCTXDataType)3, 3444 },
	{ (Il2CppRGCTXDataType)2, 1097 },
	{ (Il2CppRGCTXDataType)3, 3441 },
	{ (Il2CppRGCTXDataType)3, 9378 },
	{ (Il2CppRGCTXDataType)2, 688 },
	{ (Il2CppRGCTXDataType)3, 2317 },
	{ (Il2CppRGCTXDataType)1, 951 },
	{ (Il2CppRGCTXDataType)2, 2089 },
	{ (Il2CppRGCTXDataType)3, 3440 },
	{ (Il2CppRGCTXDataType)1, 2089 },
	{ (Il2CppRGCTXDataType)1, 1097 },
	{ (Il2CppRGCTXDataType)2, 2132 },
	{ (Il2CppRGCTXDataType)2, 2089 },
	{ (Il2CppRGCTXDataType)3, 3445 },
	{ (Il2CppRGCTXDataType)3, 3443 },
	{ (Il2CppRGCTXDataType)3, 3442 },
	{ (Il2CppRGCTXDataType)2, 212 },
	{ (Il2CppRGCTXDataType)3, 2326 },
	{ (Il2CppRGCTXDataType)2, 310 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	119,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	40,
	s_rgctxIndices,
	196,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
