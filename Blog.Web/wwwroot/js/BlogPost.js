"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

connection.on("ReceiveBlog", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " Added Post With Title : " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("PostsList").appendChild(li);
});

connection.start().then(function () {
    console.log("Connection Started");
}).catch(function (err) {
    return console.error(err.toString());
});

