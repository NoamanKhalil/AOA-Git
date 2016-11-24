//using UnityEngine;
//using System.Collections;
//using System ;
//// the heap class here is based on the article in the website below and is a heavily upgraded implmetaiton of it 
////http://www.policyalmanac.org/games/binaryHeaps.htm
//
//
//
//// class is used to sort out the open node so that it works faster  (works like a binary tree for sorting) 
////implmented to replace the list of open set as it was very slow 
//// T is to make it generic 
//// implments IHeapItem interface 
//public class Heap<T>  where T :IHeapItem<T> {
//
//	T[] items ;
//	int currentItemCount ;
//
//
//	public Heap (int maxHeapSize)
//	{
//		// new array of max heap size 
//		// max heap size is based on the number of nodes
//		items = new T [maxHeapSize] ;
//	}
//	// fucntion to add new items of the heap 
//	// each node in the heap keeps a track of itself 
//	public void Add (T item)
//	{
//		item.HeapIndex = currentItemCount ;
//		//adds new item to the ned of the array 
//		items [currentItemCount] = item ;
//		SortUp(item);
//		currentItemCount ++ ;
//		//Debug.Log ("Adding fucntion called ");
//	}
//
//	public  T RemoveFirst ()
//	{
//		T firstItem = items [0];
//		currentItemCount -- ; 
//		items[0]= items [currentItemCount];
//		items[0].HeapIndex = 0 ;
//		SortDown (items[0]);
//		//Debug.Log ("RemoveFirst"); 
//		return firstItem ;
//	}
//	//accesor to get the number of items in the heap 
//	public int Count
//	{
//		get 
//		{
//			return currentItemCount; 
//		}
//	}
//	// updates  the array by calling sortUP
//	//used to change priority in the open set if there is a change in costs
//	public void UpdateItem (T item)
//	{
//		//Debug.Log ("Items Being updated ");
//		SortUp (item);
//	}
//	public bool Contains (T item)
//	{
//		return Equals(items[item.HeapIndex],item) ;
//	}
//
//
//
//	// method to sort the  open nodes  0 == same weight -1 less wight 1 more weihgt 
//	void SortUp (T item)
//	{
//		int parentIndex = (item.HeapIndex-1)/2;
//
//		//items [currentItemCount] = items ;
//		while (true)
//		{
//			
//			T parentItem = items [parentIndex];
//			if (item.CompareTo(parentItem) >0)
//			{
//			//	Debug.Log ("Swapping items ");
//				Swap (item, parentItem);
//			}
//			else 
//			{
//				break ; 
//			}
//			parentIndex = (item.HeapIndex-1)/2;
//		}
//
//	}
//	//Parent = (n-1)/2
//	//Child ledt 2n+1
//	//Child right 2n+1 
//	void  SortDown (T item )
//	{
//		while (true)
//		{
//			int childIndexLeft = item.HeapIndex *2 +1 ;
//			int childIndexRight = item.HeapIndex *2 +2 ;
//			int swapIndex = 0 ;
//			if (childIndexLeft < currentItemCount )
//			{
//				swapIndex = childIndexLeft ;
//				if (childIndexRight <currentItemCount)
//				{
//					if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
//					{
//						swapIndex = childIndexRight ; 
//					}
//				}
//				if (item.CompareTo(items[swapIndex])< 0 )
//				{
//					Swap (item , items [swapIndex]);
//				}
//				// exits  if the parent has a higher priority than its chidlren 
//				else
//				{
//					
//					return ;
//				}
//			}
//			//exits loop when the parent has no children 
//			else 
//			{
//				return ; 
//			}
//		}
//
//	}
//	// does the swapping for the array 
//	void Swap (T itemA , T itemB) 
//	{
//		items [itemA.HeapIndex] = itemB;
//		items[itemB.HeapIndex] = itemA;
//		int itemAIndex =itemA.HeapIndex;
//		itemA.HeapIndex = itemB.HeapIndex ;
//		itemB.HeapIndex = itemAIndex ;
//	}
//}
//
//// interface to inherit from incomaprable which is used to sort & order stuff && it is part of the using namespace 
//// both are of type t 
//public interface IHeapItem<T> : IComparable<T> {
//	 int HeapIndex
//	{
//		get;
//		set;
//	}
//}