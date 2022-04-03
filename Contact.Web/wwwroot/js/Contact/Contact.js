$(document).ready(function () {
});

function getUUID(id) {
    $('#modalUUID').val($('#UUID_' + id).val());
    $('#saveModal').modal();
}

$('#saveInformations').click(function ()
{
    if (
        ($('#modalPhone').val() == "") ||
        ($('#modalEmail').val() == "") ||
        ($('#modalLocation').val() == "") ||
        ($('#modalContent').val() == "")
    ) {
        alert("Lütfen tüm alanları doldurun!");
        return;
    }
    var infos = {
        ContactUUID: $('#modalUUID').val(),
        PhoneNumber: $('#modalPhone').val(),
        Email: $('#modalEmail').val(),
        Location: $('#modalSelectLocation').val(),
        Content: $('#modalContent').val()
    }
    saveInfos(infos);

});
function saveInfos(data) {
    $.ajax({
        type: 'POST',
        url: 'https://localhost:5011/api/contactInformations',
        data: JSON.stringify(data),
        success: function (response) {
            if ((response = 200) || (response = 201)) {
                alert("Ekleme Başarılı");
                window.location.reload(1);
            }
        },
        contentType: 'application/json',
        error: function () {
            alert("Başarısız");

        }
    });
}


function deleteInformation(int) {
    $.ajax({
        type: 'Delete',
        url: 'https://localhost:5011/api/contactInformations/' + int,
        success: function (response) {
            if (response = 204) {
                window.location.reload(1);            }
        },
        error: function () {
           console.log(' silinirken bir problem oluştu.');
        }
    });
}

function deleteContact(int) {
    var id = $('#UUID_' + int).val();
    console.log(id);
    $.ajax({
        type: 'Delete',
        url: 'https://localhost:5011/api/contacts/' + id,
        success: function (response) {
            if (response = 204) {
                window.location.reload(1);
            }
        },
        error: function () {
            console.log(' silinirken bir problem oluştu.');
        }
    });
}

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
                window.location.reload(1);
            }
        },
        contentType: 'application/json',
        error: function () {
            alert("Başarısız");

        }
    });
}
//ekleme işlemleri bitiş
