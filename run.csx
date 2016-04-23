#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Verbose($"Webhook was triggered!");
    
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);
    
    //to access values send via request, use: data.value

    return req.CreateResponse(HttpStatusCode.OK, new {
        message = $"Hello World"
    });
}
