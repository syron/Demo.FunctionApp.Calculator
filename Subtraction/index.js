module.exports = function (context, data) {
    context.log('Webhook was triggered!');

    var a = data.a;
    var b = data.b;
    var c = data.c;
    
    var result = a - b - c;

    context.res = {
        body: {
            Success: true,
            Error: null,
            Result: result,
            Message: "The result of '" + a + "-" + b + "-" + c + "' is " + result
        },
        status: 200
    };

    context.done();
}
