"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
var id = 1;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg + "</br>";
    var dt = new Date();
    const sender = user;
    

    var p = document.createElement("p");
    p.textContent = message;
    p.id = "p" + id;

    var spanTime = document.createElement("span");
    spanTime.className = "time_date";
    spanTime.id = "spanTime" + id;
    spanTime.textContent = dt.getHours("hh") + ":" + dt.getMinutes() + ":" + dt.getSeconds() +" | " + user;

    var spanName = document.createElement("span");
    spanName.className = "time_date";
    spanName.style = "float:right";
    spanName.textContent = user;
   

    if (id % 2 !== 0)
    {
        var divIncoming = document.createElement("div");
        divIncoming.className = "incoming_msg";
        divIncoming.id = "divIncoming" + id;


        var divReceived = document.createElement("div");
        divReceived.className = "received_msg";
        divReceived.id = "divReceived" + id;

        var divWithd = document.createElement("div");
        divWithd.className = "received_withd_msg";
        divWithd.id = "divWithd" + id;



        document.getElementById("messagesList").appendChild(divIncoming);
        document.getElementById("divIncoming" + id).appendChild(divReceived);
        document.getElementById("divReceived" + id).appendChild(divWithd);
        document.getElementById("divWithd" + id).appendChild(p);
        document.getElementById("divWithd" + id).appendChild(spanTime);
        //document.getElementById("divWithd" + id).appendChild(spanName);

        
    }
    else {
        var divOutgoing = document.createElement("div");
        divOutgoing.className = "outgoing_msg";
        divOutgoing.id = "divOutgoing" + id;

        var divSent = document.createElement("div");
        divSent.className = "sent_msg";
        divSent.id = "divSent" + id;

        document.getElementById("messagesList").appendChild(divOutgoing);
        document.getElementById("divOutgoing" + id).appendChild(divSent);
        document.getElementById("divSent" + id).appendChild(p);
        document.getElementById("divSent" + id).appendChild(spanTime);
        //document.getElementById("divSent" + id).appendChild(spanName);
    }

    id++;
    });

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var userId = document.getElementById("userId").value;
    connection.invoke("SendMessage", user, message, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});