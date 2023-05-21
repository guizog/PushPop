namespace PushPop.Models;

public class Queue{
    public int front, rear;
    public int capacity;
    public int[] queue;
    
    public Queue(int n){
        front = rear = 0;
        capacity = n;
        queue = new int[capacity];
    }
    
    public void Enqueue(int value){
        if (capacity == rear) {
            Console.WriteLine("Fila Vazia");
            return;
        }
        queue[rear] = value;
        rear++;
    }
    
    public int Dequeue(){
        int value;
        if (front == rear) {
            Console.WriteLine("Fila Vazia");
            return -1;
        }
        value = queue[front];
        for (int i = 0; i < rear - 1; i++) {
            queue[i] = queue[i + 1];
        }
        
        if (rear < capacity)
            queue[rear] = 0;
        
        rear--; 
        return value;
    }
    public int[] ReturnQueue(){
        int[] arr = new int[rear];
        for(int i = 0; i < rear; i++){
            arr[i] = queue[i];
        }
        return arr;
    }
}

public class QueueOLD // head=tail=node se recusa a funcionar e linkar o head.next por algum motivo
{
    private Node head;
    private Node tail;
    public int size;
    
    public QueueOLD()
    {
        head = null;
        tail = null;
        size = 0;
    }
    public Node GetNode(int data)
    {
        Node node = new Node(data);
        return node;
    }
    
    public void Enqueue(int data){
        Node node = GetNode(data);
        if(tail == null){
            head = tail = node;
            size++;
            return;
        }
        tail.next = node;
        tail = node;
        size++;
    }
    
    public int Dequeue(){
        int peek = -1;
        if(head != null){
            size--;
            peek = head.data;
            head = head.next;
        }
        return peek;
    }
    
    public int Peek(){
        if(head != null){
            return head.data;
        }
        return -1;
    }
    
    public bool isEmpty(){
        if(head != null){
            return true;
        }
        return false;
    }
    
    public void PrintQueue(){
        Node curr = head;
        while(curr != null){
            Console.WriteLine(curr.data);
            curr = curr.next;
        }
    }
    
    public int[] ReturnQueue(){
        int[] arr = new int[size];
        Node curr = head;
        int i = 0;
        while (curr != null && i < size)
        {
            arr[i] = curr.data;
            curr = curr.next;
            i++;
        }
        return arr;
    }
}