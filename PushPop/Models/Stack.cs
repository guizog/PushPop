using System.Text.Json;

namespace PushPop.Models;

public class Stack
{
    static private int MaxSize = 100;
    public int Top;
    public int[] stack = new int[MaxSize];

    public Stack()
    {
        Top = -1;
    }

    public bool IsEmpty()
    {
        return (Top <= 0);
    }

    public bool Push(int value)
    {
        if (Top >= MaxSize)
        {
            Console.WriteLine("Stack Cheia");
            return false;
        }
        Top++;
        stack[Top] = value;
        return true;
    }

    public int Pop()//arrumar out of bounds
    {
        if (Top <= 0)
        {
            Console.WriteLine("Stack Vazia");
            Top--;
            return 0;
        }
        Top--;
        return stack[Top];
    }

    public void PeekStack()
    {
        if (Top < 0)
            Console.WriteLine("Stack Vazia");
        else
            Console.WriteLine("O valor no topo da stack é: " + stack[Top]);
    }

    public void PrintStack()
    {
        if (Top < 0)
            Console.WriteLine("Stack vazia");
        else
            for (int i = Top; i >= 0; i--)
                Console.WriteLine(stack[i]);
    }

    public int[] ReturnStack()
    {
        int[] newStack = new int[Top + 1];
        //inverter a sequencia dos valores
        for(int i = Top; i >= 0; i--){
            newStack[i] = stack[i];
        }
        Array.Reverse(newStack);
        return newStack;
    }
}    