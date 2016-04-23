#r "Microsoft.AspNet.WebHooks.Receivers"
#r "Microsoft.AspNet.WebHooks.Common"
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
    
    var a = int.Parse(data.a); // todo: use tryParse instead.
    var b = int.Parse(data.b); // todo: use tryParse instead.

    int result = a + b;

    return req.CreateResponse(HttpStatusCode.OK, new {
        result = result;
    });
}
