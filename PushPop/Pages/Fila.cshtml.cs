using Microsoft.AspNetCore.Mvc.RazorPages;
using PushPop.Models;

namespace PushPop.Pages;

public class Fila : PageModel
{
    public Queue modelQueue = new Queue(100);
    
    public void OnGet()
    {
        HttpContext.Session.Set<Queue>("_queue", modelQueue);
    }
    
    public void OnPostEnqueue(int enqueueValue)
    {
        modelQueue = HttpContext.Session.Get<Queue>("_queue");
        modelQueue.Enqueue(enqueueValue);
        HttpContext.Session.Set<Queue>("_queue", modelQueue);

    }

    public void OnPostDequeue()
    {
        modelQueue = HttpContext.Session.Get<Queue>("_queue");
        modelQueue.Dequeue();
        HttpContext.Session.Set<Queue>("_queue", modelQueue);
    }
}