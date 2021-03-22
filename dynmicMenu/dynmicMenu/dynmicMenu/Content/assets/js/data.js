function JsonSetData() {
    var url = '/admin/JsonFormData';
    $('#tablex').html();
    var thead = '<thead><tr><td>ID</td><td>İsim</td><td>Mail Adresi</td><td>Konu Başlığı</td><td>Mesaj</td></tr></thead>';
    $('#tablex').append(thead);
    $.getJSON(url, function (data) {
        for (var i in data.JData) {
            var deger = '<tbody><tr><td>' + data.JData[i].ID + '</td><td>' + data.JData[i].AD + '</td><td>' + data.JData[i].MAIL + '</td><td>' + data.JData[i].KONU + '</td><td>' + data.JData[i].MESAJ + '</td></tr></tbody>'
            $('#tablex').append(deger);
        }
    });
}

function JsonSetUData() {
    var url = '/admin/JsonFormUserData';
    $('#tablex').html();
    var thead = '<thead><tr><td>ID</td><td>Kullanıcı Adı</td><td>Şifre</td></thead>';
    $('#tablex').append(thead);
    $.getJSON(url, function (data) {
        for (var i in data.JData) {
            var deger = '<tbody><tr><td>' + data.JData[i].ID + '</td><td>' + data.JData[i].username + '</td><td>' + data.JData[i].password + '</td></tbody>'
            $('#tablex').append(deger);
        }
    });
}