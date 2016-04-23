module.exports = function (context, data) {
    context.log('Webhook was triggered!');

    var a = data.a;
    var b = data.b;
    
    if (b == 0) {
        context.res = {
            body: {
                Success: false,
                Error: {
                    Code: 1,
                    Message: "Provided parameter b must not be 0."
                },
                Result: null
            }
        }
        context.done();
        return;
    }
    
    var result = a / b;

    context.res = {
        body: {
            Success: true,
            Error: null,
            Result: result
        },
        status: 200
    };

    context.done();
}
