"use strict";

// ������������� ���������� � Hub
var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/DeviceHub").build();

// �������� �� ������������� ����������
$(function () {
    connection.start().then(function () {
        console.log('Connected to SignalR');
        InvokeGpsData(); // ��������� �������������� ��������� ������
        setInterval(InvokeGpsData, 2000); // ������ 5 ������ ����������� ������
    }).catch(function (err) {
        return console.error(err.toString());
    });
});

// ��������� ������� ��������� ������
function InvokeGpsData() {
    connection.invoke("SendGPsDataFromDatabase").catch(function (err) {
        return console.error(err.toString());
    });
}

// ����������� � ��������� ������ � GPS � �������� ������
connection.on("ReceivedGPSdata", function (GPSdata) {
    BindGPSdataToBorder(GPSdata);
});

// �������� ������ � �������
function BindGPSdataToBorder(GPSdata) {
    const ul = $('#rBorder ul');
    ul.empty(); // �������� ���������� ������

    GPSdata.forEach(function (item) {
        // ������� ������� ������ ��� ������� ����������
        const listItem = $('<li></li>')
            .append(`<strong>Device ID:</strong> ${item.deviceId}<br>`)
            .append(`<strong>Latitude:</strong> ${item.latitude}<br>`)
            .append(`<strong>Longitude:</strong> ${item.longitude}`);

        ul.append(listItem); // ��������� ������� � ������
    });
}
