$(document).ready(function () {

    var table = $('#example').DataTable({

        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });

    table.buttons().container()
        .insertBefore('#example_filter');
});