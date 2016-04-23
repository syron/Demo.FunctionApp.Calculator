module.exports = function (context, data) {
    context.log('Webhook was triggered!');

    var a = data.a;
    var b = data.b;
    
    var result = a - b;

    context.res = {
        body: {
            Status: true,
            Error: null,
            Result: result
        },
        status: 200
    };

    context.done();
}
