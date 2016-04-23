public class Error {
    public Error() {}
    public Error(int code, string message) {
        this.Code = code;
        this.Message = message;
    }
    public int Code {get;set;}
    public string Message {get;set;}
} 

public class ApiResult {
    public ApiResult() {}
    public int? Result {get;set;}
    public Error Error {get;set;}
    public bool Success {get;set;}
}