$(document).ready(function () {
    $('#myTable').DataTable({
        order: [[3, 'desc'], [0, 'asc']]
    });
});