public class Queue {
    Stack<int> main = new Stack<int>();
    Stack<int> copy = new Stack<int>();
    
    // Push element x to the back of queue.
    public void Push(int x) {
        if(main.Count > 0)
        {
            while(main.Count > 0)
            {
                copy.Push(main.Pop());
            }
           
            main.Push(x);
           
            while(copy.Count > 0)
            {
                main.Push(copy.Pop());
            }
        }
        else
        {
            main.Push(x);
        }
    }

    // Removes the element from front of queue.
    public void Pop() {
        main.Pop();
    }

    // Get the front element.
    public int Peek() {
        return main.Peek();
    }

    // Return whether the queue is empty.
    public bool Empty() {
        if(main.Count == 0)
        {
            return true;
        }
        return false;
    }
}