$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:5011/api/contacts',
        success: function (data) {
            console.log(data);

            var myvar = "<tr><td>html data</td> </tr>";
            $('#InformationItems').html(myvar)
        },
        contentType: 'application/json',
        error: function () {
            
        }
    });
});

//ekleme işlemleri başlangıç
$('#btnSaveContact').click(function () {

    if (
        ($('#inputName').val() == "") ||
        ($('#inputSurName').val() == "") ||
        ($('#inputCompany').val() == "") ||
        ($('#inputPhone').val() == "") ||
        ($('#inputEmail').val() == "") ||
        ($('#inputLocation').val() == "") ||
        ($('#inputContent').val() == "")
    ) {
        alert("Lütfen tüm alanları doldurun!");
        return;
    }

    var contact = {
        Name: $('#inputName').val(),
        SurName: $('#inputSurName').val(),
        Company: $('#inputCompany').val(),
        PhoneNumber: $('#inputPhone').val(),
        Email: $('#inputEmail').val(),
        Location: $('#selectLocation').val(),
        Content: $('#inputContent').val()
    }
    saveContact(contact);
});
function saveContact(data) {
    $.ajax({
        type: 'POST',
        url: 'https://localhost:5011/api/contacts',
        data: JSON.stringify(data),
        success: function (response) {
            if ((response = 200) || (response = 201)) {
                alert("Ekleme Başarılı");
                console.log(response.data);
            }
        },
        contentType: 'application/json',
        error: function () {
            alert("Başarısız");

        }
    });
}
//ekleme işlemleri bitiş
