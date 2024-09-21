var customIcon = L.icon({
    iconUrl: 'https://static.thenounproject.com/png/1925328-200.png', // Путь к изображению иконки
    iconSize: [38, 38], // Размер иконки [ширина, высота]
    iconAnchor: [19, 38], // Точка привязки иконки (центр или нижняя часть)
    popupAnchor: [0, -38] // Точка привязки для окна с информацией
});

// Создаем карту и устанавливаем начальную позицию на Москву
var map = L.map('map').setView([55.7558, 37.6173], 10); // Центрируем карту на Москве

// Добавляем слой OpenStreetMap
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
    {
        maxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

// Получаем данные об устройствах через глобальную переменную deviceData, которую передадим из представления
deviceData.forEach(function (item) {
    var lat = parseFloat(item.Latitude);
    var lng = parseFloat(item.Longitude);

    if (!isNaN(lat) && !isNaN(lng)) {
        var marker = L.marker([lat, lng], { icon: customIcon }).addTo(map);
        marker.bindPopup("<b>Device ID:</b> " + item.DeviceId + "<br><b>Latitude:</b> " + lat + "<br><b>Longitude:</b> " + lng);
    }
    else {
        console.error('Invalid coordinates for Device ID: ' + item.DeviceId);
    }
});

