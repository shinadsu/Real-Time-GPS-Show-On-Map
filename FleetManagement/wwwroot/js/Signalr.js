"use strict";

// Устанавливаем соединение с Hub
var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/DeviceHub").build();

// Проверка на установленное соединение
$(function () {
    connection.start().then(function () {
        console.log('Connected to SignalR');
        InvokeGpsData(); // Запускаем первоначальное получение данных
        setInterval(InvokeGpsData, 2000); // Каждые 5 секунд запрашивать данные
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

// Запускаем процесс получения данных
function InvokeGpsData() {
    connection.invoke("SendGPsDataFromDatabase").catch(function (err) {
        return console.error(err.toString());
    });
}

// Уведомление о получении данных с GPS и вызываем методы
connection.on("ReceivedGPSdata", function (GPSdata) {
    BindGPSdataToBorder(GPSdata);
});

// Привязка данных к бордеру
function BindGPSdataToBorder(GPSdata) {
    const ul = $('#rBorder ul');
    ul.empty(); // Очистить предыдущие данные

    GPSdata.forEach(function (item) {
        // Создаем элемент списка для каждого устройства
        const listItem = $('<li></li>')
            .append(`<strong>Device ID:</strong> ${item.deviceId}<br>`)
            .append(`<strong>Latitude:</strong> ${item.latitude}<br>`)
            .append(`<strong>Longitude:</strong> ${item.longitude}`);

        ul.append(listItem); // Добавляем элемент в список
    });
}
