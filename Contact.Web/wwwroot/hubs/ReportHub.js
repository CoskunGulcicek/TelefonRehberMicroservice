$(document).ready(() => {
    //window.paceOptions = { ajax: { ignoreURLs: ['mainHub', '__browserLink', 'browserLinkSignalR'], trackWebSockets: false } }
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5012/reporthub")//istek atacağımız url port hub ismi
        .withAutomaticReconnect()//bağlantı kopunca tekrar bağlanmayı deneyecek
        .build();

    async function start() {
        try {
            await connection.start();
        } catch (error) {
            setTimeout(() => start(), 2000);
        }
    }


    //Object.defineProperty(WebSocket, 'OPEN', { value: 1, });
    start();

    connection.onreconnecting(error => {
        console.log("Bağlantı kuruluyor...");
    });

    connection.onreconnected(connectionId => {
        console.log("Bağlantı kuruldu...");
    });

    connection.onclose(connectionId => {
        console.log("Bağlanılamadı...");
    });


    connection.on("userJoined", connectionId => {
        console.log(`${connectionId} bağlandı.`);
    });

    connection.on("userLeaved", connectionId => {
        console.log(`${connectionId} ayrıldı.`);
    });


    connection.on("receiveMessage", message => {
        console.log(message);
    });

    connection.on("takeReports", report => {
        $("#reportId").val(report.id);
        document.getElementById("btnRaporIndir").disabled = false;
            alert("rapor indirmeye hazır");
            return;
    });

});