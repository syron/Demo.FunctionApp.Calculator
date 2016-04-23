#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Verbose($"Webhook was triggered!");
    
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);
        
    int a = int.Parse(data.a);
    int b = int.Parse(data.b);
        
    
    return req.CreateResponse(HttpStatusCode.OK, new {
        status: 1,
        error: null,
        result: (a + b)
    });
}
