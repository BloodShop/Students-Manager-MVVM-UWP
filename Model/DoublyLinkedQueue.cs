using System;
using System.Collections;

namespace Model
{
    public class QNode<T> where T : class
    {
        public T Data { get; private set; }
        public QNode<T> Next { get; internal set; }
        public QNode<T> Prev { get; internal set; }
        public QNode(T data, QNode<T> prev)
        {
            Data = data;
            Next = null;
            Prev = prev;
        }
    }
    public class DoublyLinkedQueue<T> : /*ObservableCollection<T>,*/ IEnumerable where T : class // My queue
    {
        QNode<T> _front;
        QNode<T> _last;
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Remove all obejects from <see cref="DoublyLinkedQueue{T}"/>
        /// </summary>
        public void Clear()
        {
            _front = null;
            _last = null;
            Size = 0;
        }
        /// <summary>
        /// Retrieve the element's Node
        /// </summary>
        /// <param name="element">Data</param>
        /// <returns></returns>
        public QNode<T> Element(T element) // O(n)
        {
            if (IsEmpty()) return null;
            for (QNode<T> p = _front; p != null; p = p.Next)
                if (p.Data == element) return p;
            return null;
        }
        /// <summary>
        /// Add Node<T> with a condition
        /// </summary>
        /// <param name="data">The data you want to pass <see cref="T"/></param>
        /// <param name="predicate">Condition where the Node will be added</param>
        /// <returns></returns>
        public QNode<T> Add(T data, Predicate<T> predicate) // O(n) 
        {
            if (_last != null && predicate(_last.Data)) return EnQueue(data);

            for (QNode<T> p1 = _front; p1 != null; p1 = p1.Next)
                if (!predicate(p1.Data))
                    return AddBefore(data, p1);

            return EnQueue(data);
        }
        QNode<T> AddBefore(T data, QNode<T> before) // O(1)
        {
            var @new = new QNode<T>(data, null);
            if (before.Prev == null)
            {
                before.Prev = @new;
                @new.Next = before;
                @new.Prev = null;
                _front = @new;
                Size++;
            }
            else
            {
                @new.Prev = before.Prev;
                @new.Next = before;
                before.Prev.Next = @new;
                before.Prev = @new;
                Size++;
            }
            return @new;
        }
        /// <summary>
        /// Add an object to the end of the <see cref="DoublyLinkedQueue{T}"/>
        /// </summary>
        /// <param name="data">The data you want to pass <see cref="T"/></param>
        /// <returns></returns>
        public QNode<T> EnQueue(T data) // Add a node into queue O(1) 
        {
            if (data == null) return null; // Also could throw an Exception
            var node = new QNode<T>(data, _last); // Create a new node
            if (IsEmpty())
            {
                _front = node; // When adding a first node of queue
                Size = 1;
            }
            else
            {
                _last.Next = node;
                Size++;
            }
            return _last = node;
        }
        /// <summary>
        /// Boolean function Return wheather the queue is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Size == 0;
        /// <summary>
        ///  Returns the object at the beggining of the <see cref="DoublyLinkedQueue{T} without removing it"/>
        /// </summary>
        /// <returns></returns>
        public T Peek() // Get a front data of queue O(1) 
        {
            if (IsEmpty())
                return null;
            return _front.Data;
        }
        /// <summary>
        /// Removes and return the front object of the <see cref="DoublyLinkedQueue{T}"/>
        /// </summary>
        /// <returns></returns>
        public T DeQueue() // Removes and return the front object of the queue O(1) 
        {
            if (IsEmpty())
                return null;

            var data = Peek();
            if (_front == _last) // When queue contains only one node
            {
                _last = null;
                _front = null;
            }
            else
            {
                _front = _front.Next;
                _front.Prev = null;
            }
            Size--;
            return data;
        }
        /// <summary>
        /// Deletes an un-known node by giving the data of the node - O(n)
        /// </summary>
        /// <param name="data">The data you are searching for <see cref="T"/></param>
        public void DeleteNode(T data) // O(n) 
        {
            if (IsEmpty()) return; // Base case
            for (QNode<T> p = _front; p != null; p = p.Next)
                if (p.Data == data)
                {
                    DeleteNode(p);
                    return;
                }
        }
        /// <summary>
        /// Deletes the given node if exists - O(1)
        /// </summary>
        /// <param name="del">The node you are searching for <see cref="QNode{T}"/></param>
        public void DeleteNode(QNode<T> del) // Deletes the given node if exists O(1) 
        {
            if (IsEmpty()) return; // Base case

            if (del.Prev == null && del.Next == null) // if only one element in the queue
            {
                Clear();
                return;
            }
            if (del.Prev == null) // first element
            {
                _front = del.Next;
                if (_front != null) _front.Prev = null;
            }
            else if (del.Next == null) // last element
            {
                _last = del.Prev;
                if (_last != null) _last.Next = null;
            }
            else // some-where inside the queue
            {
                del.Prev.Next = del.Next;
                del.Next.Prev = del.Prev;
            }
            Size--;
            return;

            #region One-way LinkedList queue
            //// If node to be deleted is Front node
            //if (Front == del)
            //    Front = del.Next;

            //// Change next only if node to be deleted is NOT the last node
            //if (del.Next != null)
            //    del.Next.Prev = del.Prev;

            //// Change prev only if node to be deleted is NOT the first node
            //if (del.Prev != null)
            //    del.Prev.Next = del.Next;

            //// Finally, free the memory occupied by del
            #endregion
        }
        /// <summary>
        /// Return an enumertor that iterates through the <see cref="DoublyLinkedQueue{T}"/> - O(n)
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() // Enumerates through all the elements in queue 
        {
            var node = _front;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }
        /// <summary>
        /// Prints the Data of the queue
        /// </summary>
        /// <param name="action">The action you want to pass wheather it's console -> c.w</param>
        public void PrintQdata(Action<string> action) // Print elements of queue 
        {
            var node = _front;
            action("\nQueue Element");
            while (node != null)
            {
                action($" {node.Data}");
                node = node.Next;
            }
            action("\n");
        }
    }
}