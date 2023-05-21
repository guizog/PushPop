using System.Text.Json;

namespace PushPop.Models;

public class Stack
{
    public int size;
    public Node? head;
    public Node? tail;
    
    public Stack(){
        size = 0;
        head = null;
        tail = null;
    }
    
    public Node GetNode(int data)
    {
        Node node = new Node(data);
        return node;
    }
    
    public void Push(int value){
        Node node = new Node(value);
        
        if(head == null){
            node.next = null;
        }
        else{
            node.next = head;
        }
        size++;
        head = node;
    }
    
    public int Pop(){
        if(head == null){
            return -1;
        }
        int data = head.data;
        size--;
        head = head.next;
        return data;
    }
    
    public int[] ReturnStack(){
        Node curr = head;
        int[] arr = new int[size];
        int i = 0;
        while(curr != null){
            arr[i] = curr.data;
            i++;
            curr = curr.next;
        }
        return arr;
    }
    
    public bool isEmpty(){
        return (size <= 0);
    }
}    