var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { "data": 'name', "width": "25%" },
            { "data": 'streetAddress', "width": "20%" },
            { "data": 'city', "width": "10%" },
            { "data": 'state', "width": "20%" },
            { "data": 'phoneNumber', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Editar </a>
                        <a OnClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash"></i> Eliminar </a>
                    </div>`
                },
                "width": "35%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Deseas eliminar la compañia?',
        text: "Este cambio no podra revertirse",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminalo'
    }).then((result) => {
        $.ajax({
            url: url,
            type: 'Delete',
            success: function (data) {
                dataTable.ajax.reload();
                toastr.success(data.message);
            }
        })
    })
}
