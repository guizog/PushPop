using System.Net;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PushPop.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PushPop.Pages;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}

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
        Message = "Testando";
        HttpContext.Session.Set<Stack>("_stack", modelStack);
    }
    
    public void OnPostPush(int pushValue)
    {
        modelStack = HttpContext.Session.Get<Stack>("_stack");
        modelStack.Push(pushValue);
        HttpContext.Session.Set<Stack>("_stack", modelStack);

    }

    public void OnPostPop()
    {
        modelStack = HttpContext.Session.Get<Stack>("_stack");
        modelStack.Pop();
        HttpContext.Session.Set<Stack>("_stack", modelStack);

    }
    
}