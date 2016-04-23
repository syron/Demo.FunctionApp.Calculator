#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Verbose($"Webhook was triggered!");
    
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);
        
    int a;
    bool parseResult = Int32.TryParse(data.a, out a);
    
    if (!parseResult) {
        return req.CreateResponse(HttpStatusCode.BadRequest, new {
            status: 0,
            error: {
                message: "Could not parse a",
                code: 2
            },
            result: null
        }); 
    }
    
    int b;
    parseResult = Int32.TryParse(data.b, out b);
    
    if (!parseResult) {
        return req.CreateResponse(HttpStatusCode.BadRequest, new {
            status: 0,
            error: {
                message: "Could not parse b",
                code: 3
            },
            result: null
        }); 
    }
        
    
    return req.CreateResponse(HttpStatusCode.OK, new {
        status: 1,
        error: null,
        result: (a + b)
    });
}
