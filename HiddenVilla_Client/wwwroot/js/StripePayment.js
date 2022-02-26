redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51KXAXAIQMAEpEmNHMbjLxDQTos8LVyqQVtotaDPja19oksmQzU6usCnbyL1vvynR8wGMQZfvw1KB36HsIwxFrzGY00gKwXqdzW');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};