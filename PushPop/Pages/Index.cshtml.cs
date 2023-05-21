using System.Net;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PushPop.Models;

namespace PushPop.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string Message { get; set; }
    public Stack modelStack = new Stack();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        HttpContext.Session.Set<Stack>("_stack", modelStack);
    }
    
    public void OnPostPush(int pushValue)
    {
        modelStack = HttpContext.Session.Get<Stack>("_stack");
        modelStack.Push(pushValue);
        foreach (int a in modelStack.ReturnStack())
            Console.WriteLine(a);
        HttpContext.Session.Set<Stack>("_stack", modelStack);

    }

    public void OnPostPop()
    {
        modelStack = HttpContext.Session.Get<Stack>("_stack");
        modelStack.Pop();
        HttpContext.Session.Set<Stack>("_stack", modelStack);
    }
}