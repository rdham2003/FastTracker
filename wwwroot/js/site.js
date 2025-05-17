// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    console.log("Hello World!");
    $('.EditJob').hide();
})

$('#addJobs').click(function () {
    console.log("Add");
    $('#form').fadeIn(1000);
});

$(document).ready(function () {
    $('[id^="edit"]').click(function () {
        let jobId = this.id + "frm";
        console.log("#" + jobId);
        editJobWithId(jobId);
    });
});
function editJobWithId(jobId) { 
    //$('.EditJob').hide();
    $("#" + jobId).show();
}



//$('#delete').click(function () {
//    console.log("Delete");
//});