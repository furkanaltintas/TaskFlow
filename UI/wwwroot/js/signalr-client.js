document.addEventListener("DOMContentLoaded", function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/taskHub")
        .build();

    connection.start().then(() => {
        console.log("SignalR bağlantısı kuruldu.");
    }).catch(err => console.error("SignalR bağlantı hatası:", err));

    connection.on("ReceiveTask", function (task) {
        console.log("Yeni görev alındı:", task);

        let table = document.getElementById("taskTable");
        if (!table) {
            console.error("Tablo bulunamadı!");
            return;
        }

        let row = document.createElement("tr");
        row.innerHTML = `
            <td>${task.title}</td>
            <td>${task.description}</td>
            <td>${task.state}</td>
            <td>${task.user?.username || "Bilinmiyor"}</td>
            <td>${task.priority?.definition || "Tanımsız"}</td>
        `;
        table.appendChild(row);
    });
});
