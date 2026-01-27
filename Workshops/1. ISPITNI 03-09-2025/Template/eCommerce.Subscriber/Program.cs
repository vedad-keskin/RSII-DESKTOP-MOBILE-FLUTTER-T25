using EasyNetQ;
using eCommerce.Model.Messages;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var bus = RabbitHutch.CreateBus("host=localhost");


await bus.PubSub.SubscribeAsync<ProductUpdated>("console_printer", msg => {
    Console.WriteLine($"Product {msg.Product.Name} was updated");
    return Task.CompletedTask;
});

// await bus.PubSub.SubscribeAsync<ProductUpdated>("mail_sender", msg => {
//     Console.WriteLine($"Mail for product {msg.Product.Name} was sent");
//     return Task.CompletedTask;
// });

// await bus.PubSub.SubscribeAsync<ProductUpdated>("console_printer", msg => {
//     Console.WriteLine($"Product {msg.Product.Name} was updated from antother subscriber");
//     return Task.CompletedTask;
// });


Console.WriteLine("Press any key to exit");
Console.ReadKey();