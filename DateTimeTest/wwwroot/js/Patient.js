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
            showDetailsPatientsModal();
            showEditPatientsModal();
        },
        "ajax": {
            "url": $("table#patients-datatable").data("url"),
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "name": "PatientID", "autowidth": true },
            { "data": "rM2Number", "name": "RM2Number", "autowidth": true },
            { "data": "nhsNumber", "name": "NHSNumber", "autowidth": true },
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
            { "data": "gender", "name": "Gender", "autowidth": true },
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

    var initPatientModal = function () {

    };

    var showDetailsPatientsModal = function () {
        $(document).off("click.dpm").on("click.dpm", "a.details-patient-link", function (e) {
            e.preventDefault();
            let patientID = $(this).data("patientID");
            let detailsUrl = $(this).attr("href");
            $.get(detailsUrl, function (htmlResponse) {
                $("div#modal-container").html(htmlResponse);
                $("div#details-patient-modal").modal("show");
            });
        });
    };

    var showEditPatientsModal = function () {
        $(document).off("click.epm").on("click.epm", "a.edit-patient-link", function (e) {
            e.preventDefault();
            let patientID = $(this).data("patientID");
            let editUrl = $(this).attr("href");
            $.get(editUrl, function (htmlResponse) {
                $("div#modal-container").html(htmlResponse);
                $("div#edit-patient-modal").modal("show");
                $("div#edit-patient-modal").on("shown.bs.modal", function () {
                    $("input.datepicker").datepicker({
                        format: "dd/MM/yyyy"
                    });
                    onPatientUpdateSubmit();
                });
            });
        });
    };

    var onPatientUpdateSubmit =function() {
        $(document).off("click.sup").on("click.sup", "button#save-update-patient", function (e) {
            e.preventDefault();
            $("label.text-danger").html("");
            let initialRm2 = $("input#RM2Number").val().trim();
            let formData = $("form#edit-patient").serialize();
            let formAction = "/Patients/Update";
            $.post(formAction, formData, function (response) {
                if (response.errors) {
                    displayErrors(response.errors);
                } else {
                    window.patientsTable.ajax.reload();
                    $("div#edit-patient-modal").modal.hide;
                    $("input.RM2Number").val(initialRm2).trigger("change");
                }
            });
        });
    };

    return {
        init: function () {
            initPatientModal();
            initializePatientsTable();
        }
    };
}();