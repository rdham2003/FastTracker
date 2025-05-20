// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    console.log("Hello World!");
    $('.EditJob').hide();
    switch ($('#job_status').text) {
        case "REJECTED":
            $('.Job_Container').css('background', '#EF4444'); 
            break;
        case "WAITLISTED":
            $('.Job_Container').css('background', '#F97316'); 
            break;
        case "APPLIED":
            $('.Job_Container').css('background', '#FACC15'); 
            break;
        case "OA":
            $('.Job_Container').css('background', '#A3E635'); 
            break;
        case "PHONE_SCREEN":
            $('.Job_Container').css('background', '#86EFAC'); 
            break;
        case "INTERVIEW":
            $('.Job_Container').css('background', '#4ADE80'); 
            break;
        case "OFFER":
            $('.Job_Container').css('background', '#22C55E'); 
            break;
        case "ACCEPTED":
            $('.Job_Container').css('background', '#16A34A'); 
            break;
        case "UNKNOWN":
            $('.Job_Container').css('background', '#D1D5DB');
            break;
        default:
            $('.Job_Container').css('background', '#E5E7EB'); 
            break;
    }
});

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

$('#SubmitEdit').click(function () {
    switch ($('#job_status').text) {
        case "REJECTED":
            $('.Job_Container').css('background', '#EF4444');
            break;
        case "WAITLISTED":
            $('.Job_Container').css('background', '#F97316');
            break;
        case "APPLIED":
            $('.Job_Container').css('background', '#FACC15');
            break;
        case "OA":
            $('.Job_Container').css('background', '#A3E635');
            break;
        case "PHONE_SCREEN":
            $('.Job_Container').css('background', '#86EFAC');
            break;
        case "INTERVIEW":
            $('.Job_Container').css('background', '#4ADE80');
            break;
        case "OFFER":
            $('.Job_Container').css('background', '#22C55E');
            break;
        case "ACCEPTED":
            $('.Job_Container').css('background', '#16A34A');
            break;
        case "UNKNOWN":
            $('.Job_Container').css('background', '#D1D5DB');
            break;
        default:
            $('.Job_Container').css('background', '#E5E7EB');
            break;
    }
})

//$('#delete').click(function () {
//    console.log("Delete");
//});

 