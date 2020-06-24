var Patients = function () {

    var moveSearchFieldsFromFooterToHead = function () {
        var r = $('#patients-datatable tfoot tr');
        r.find('th').each(function () {
            $(this).css('padding', 8);
        });
        $('#patients-datatable thead').append(r);
        $('#search_0').css('text-align', 'center');
        $("div#patients_datatable_filter").hide();
        $("input.Actions").remove();
        $("input.DOB").remove();
        $("input.Gender").remove();
    };
    var addFilteringColumns = function () {
        $('#patients-datatable tfoot th').each(function () {

        });

        window.patientsTable.columns().every(function () {
            var that = this;

            $('input', this.footer()).on('keyup change', function () {
                if (that.search() !== this.value) {
                    that
                        .search(this.value)
                        .draw();
                }
            });
        });
    };

    var initializePatientsTable = function () {
        window.patientsTable = $("table#patients-datatable").DataTable({
        "dom": "<'row'<'col-sm-6'l><'col-sm-6'f><'col-sm-6'p>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "processing": true,
        "serverSide": true,
        "filter": true,
        "responsive": true,
        "pageLength": 10,
        "initComplete": function (settings, json) {
            addFilteringColumns();
            moveSearchFieldsFromFooterToHead();

        },
        "ajax": {
            "url": $("table#patients-datatable").data("url"),
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "name": "PatientID", "autowidth": true },
            { "data": "rM2Number", "name": "RM2Number", "autowidth": true },
            { "data": "lastName", "name": "LastName", "autowidth": true },
            { "data": "firstName", "name": "FirstName", "autowidth": true },
            {
                "data": "dob", "name": "DOB", "autowidth": true,
                "render": function (data, type, object, meta) {
                    if (!object.dob) return "";
                    let date = moment.unix(object.dob).format("DD/MM/YYYY");
                    return date;
                }
            },
            {
                "render": function (data, type, object, meta) {
                    //buttons can be render here with HTML
                    return '<a class="btn btn-primary details-patient-link"  href="/Patients/Details?patientId=' + object.id + '" data-id="' + object.id + '" data-toggle="tooltip" data-title="Patient Details" ><i class=\'fa fa-info-circle\' ></i>&nbsp;</a>&nbsp;' +
                        '<a class="btn btn-warning edit-patient-link"  href="/Patients/Edit?patientId=' + object.id + '" data-id="' + object.id + '" data-toggle="tooltip" data-title="Edit Patient" ><i class=\'fa fa-edit\' ></i>&nbsp;</a>&nbsp;' +
                        '<a class="btn btn-danger del-patient-link"  href="/Patients/Delete?patientId=' + object.id + '" data-id="' + object.id + '" data-toggle="tooltip" data-title="Delete Patient" ><i class=\'fa fa-trash\' ></i>&nbsp;</a>&nbsp;'
                },
                "sortable": false,
                "width": 250,
                "autoWidth": false
            }
        ]
        });
    };
    return {
        init: function () {
            initializePatientsTable();
        }
    };
}();