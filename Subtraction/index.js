module.exports = function (context, data) {
    context.log('Webhook was triggered!');

    var a = data.a;
    var b = data.b;
    
    var result = a - b;

    context.res = {
        body: {
            Success: true,
            Error: null,
            Result: result,
            Message: "The result of '" + a + "-" + b + "' is " + result
        },
        status: 200
    };

    context.done();
}
