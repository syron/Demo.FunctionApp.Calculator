#r "Newtonsoft.Json"
#load "models.csx"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Verbose($"Webhook was triggered!");
    
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);
    
    ApiResult result = new ApiResult();
    
    if (data.a == null || data.b == null) {
        result.Success = false;
        result.Error = new Error(1, "Please provide both a and b as paremeters.");
        return req.CreateResponse(HttpStatusCode.BadRequest, result);
    }
    
    int a = int.Parse(data.a.ToString());
    int b = int.Parse(data.b.ToString());
    
    int sum = a + b;
    result.Result = sum;
    return req.CreateResponse(HttpStatusCode.OK, result);
}