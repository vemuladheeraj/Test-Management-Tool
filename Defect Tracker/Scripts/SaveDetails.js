function onchangerelasename() {

    //alert('Test for on change' +rname);
    debugger;
    var rname = document.querySelector('#releasename').value;
    //document.querySelector("#exit").textContent = rname;
    document.getElementById('exit').innerHTML = rname + " Release";
    var serviceURL = 'PostReleaseData';
    $.ajax({
        type: 'POST',
        url: serviceURL,
        data: '{param:"' + rname + '"}',

        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $("#resultDiv").html(response);
            // alert('success');
        },
        error: errorFunc
    });

    function successFunc(data, status) {
        debugger;
        alert(status);
    }

    function errorFunc() {
        alert('ERROrRINFO');
    }
};
function DefectDetails() {
    if (document.getElementById('dtitle').value == "" || document.getElementById('ddesc').value == "" || document.getElementById('drepro').value == "") {
        alert("Fill All Fields !");
    } else {
        debugger;
        //var ticketid = selectedTd;
        var selectedTd = $('table').find('tbody').find('tr').has("input[type='checkbox']:checked").find('td.ticket').text();
        var ticketid = selectedTd.toString();
        //String ticketid =(String) selectedTd;
        var deftitle = document.getElementById('dtitle').value;
        var DefectDesc = document.getElementById('ddesc').value;
        var DefSteps = document.getElementById('drepro').value;
        //var serviceURL = 'InsertTicketDetails';
        $.ajax({
            type: 'POST',
            url: '@Url.Action("InsertDefectDetails", "Home")',
            data: '{ticketid:"' + ticketid + '", deftitle:"' + deftitle + '", DefectDesc:"' + DefectDesc + '", DefSteps:"' + DefSteps + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (response) {
                //@*@Html.Partial("PartialIndex2")*@
                document.getElementById('id03').style.display = 'none';
                alert("Defect added Sucessfully");
                // alert('success');
            },
            error: errorFunc
        });
        function errorFunc(e) {
            alert('There was some error on inserting the defect details : ' + e);
        }
    }
}

//function check_empty1() {
//    if (document.getElementById('ttitle').value == "" || document.getElementById('tdes').value == "" || document.getElementById('tstate').value == "") {
//        alert("Fill All Fields !");
//    } else {
//        document.getElementById('ticketpopup').submit();
//        //var dr4 = document.getElementById('displayrelname').value;
//        var rname = document.querySelector('#releasename').value;
//        var dr1 = document.getElementById('ttitle').value;
//        var dr2 = document.getElementById('tstate').value;
//        var dr3 = document.getElementById('tdes').value;
//        var serviceURL = 'InsertTicketDetails';
//        $.ajax({
//            type: 'POST',
//            url: serviceURL,
//            data: '{param1:"' + rname + '", param2:"' + dr1 + '", param3:"' + dr2 + '", param4:"' + dr3 + '"}',
//            contentType: "application/json; charset=utf-8",
//            dataType: "html",
//            success: function (response) {

//                alert("Saved Sucessfully");
//                // alert('success');
//            },
//            error: errorFunc
//        });
//        function errorFunc(e) {
//            alert('There was some error on inserting the ticket details : ' + e);
//        }
//        //alert("Form Submitted Successfully...");
//    }
//}
function SaveTicketDetails() {
    if (document.getElementById('ttitle').value == "" || document.getElementById('tdes').value == "" || document.getElementById('tstate').value == "") {
        alert("Fill All Fields !");
    } else {
        //document.getElementById('ticketpopup').submit();
        //var dr4 = document.getElementById('displayrelname').value;
        var rname = document.querySelector('#releasename').value;
        var dr1 = document.getElementById('ttitle').value;
        var dr2 = document.getElementById('tstate').value;
        var dr3 = document.getElementById('tdes').value;
        //var serviceURL = 'InsertTicketDetails';
        $.ajax({
            type: 'POST',
            url: '@Url.Action("InsertTicketDetails","Home")',
            data: '{param1:"' + rname + '", param2:"' + dr1 + '", param3:"' + dr2 + '", param4:"' + dr3 + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (response) {
                //@*@Html.Partial("PartialIndex2")*@
                alert("Saved Sucessfully");
                // alert('success');
            },
            error: errorFunc
        });
        function errorFunc(e) {
            alert('There was some error on inserting the ticket details : ' + e);
        }
        //alert("Form Submitted Successfully...");
    }
}

function saveReleaseData() {

    var releaseDesc = document.getElementById('relname').value;
    if (releaseDesc == "") {
        alert("Please Enter Valid Release Name");
    }
    else {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("UpdateReleasedata")',
            dataType: 'json',
            data: { releaseName: releaseDesc },
            success: function (data) {

                alert('Release Added Successfully');
            },
            error: function (ex) {
                alert("Some Error");
                console.log(ex);
            }
        });
    }
}
function closeReleaseDataWindow() {

    event.preventDefault();
    document.getElementById('id02').style.display = 'none';

}
//function check_empty2() {
//    if (document.getElementById('relname').value == "") {
//        alert("Enter Release Name!");
//    } else {
//        var formId = document.getElementById('form');
//        formId.submit();
//        var rename = document.getElementById('relname').value;
//        var serviceURL = 'UpdateReleasedata';
//        $.ajax({
//            type: 'POST',
//            url: serviceURL,
//            data: '{param:"' + rename + '"}',

//            contentType: "application/json; charset=utf-8",
//            dataType: "html",
//            success: function (response) {
//                alert("Release Added");
//                // alert('success');
//            },
//            error: errorFunc
//        });
//        function errorFunc() {
//            alert('There was some error on updating the Release Name');
//        }
//    }
//}

function chart() {
    alert('Boom!');
}
function ReportDefect() {
    alert('There are no Defects in this page. Close the popup and do your work!');
}
//Function To Display Popup
function div_show() {
    document.getElementById('abc').style.display = "block";
}
//Function to Hide Popup
function div_hide() {
    document.getElementById('abc').style.display = "none";
}
//function div_show1() {
//    var rname = document.querySelector('#releasename').value;
//    document.getElementById('abc1').style.display = "block";
//    document.getElementById('displayrelname').innerHTML = rname + "Release";
//}
//Function to Hide Popup
function div_hide1() {
    document.getElementById('abc1').style.display = "none";
}

function div_show2() {
    document.getElementById('abc2').style.display = "block";
}
//Function to Hide Popup
function div_hide2() {
    document.getElementById('abc2').style.display = "none";
}
function searchTid() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}


function addticketdetailspopup() {
    document.getElementById('id01').style.display = 'block';
    var rname = document.querySelector('#releasename').value;
    document.getElementById('displayrelname').innerHTML = rname + " Release";
};
function addreleasedetailspopup() {
    document.getElementById('id02').style.display = 'block';

};
function adddefectdetailspopup() {
    // debugger;
    //var selectedTd = $('.ticketNumber').text();


    var selectedTd = $('table').find('tbody').find('tr').has("input[type='checkbox']:checked").find('td.ticket').text();
    $("#displayId").text(selectedTd);
    document.getElementById('id03').style.display = 'block';
    //document.getElementById('dtitle').innerHTML = +"";
};

function editTicketDetails() {
    // var selectedTd = $('table').find('tbody').find('tr').has("input[type='checkbox']:checked").find('td:nth-child(7)');
    debugger;
    var selectedTd = $('table').find('tbody').find('tr').has("input[type='checkbox']:checked").find('td.editable');
    selectedTd.css('background-color', '#A9A9A9');
    selectedTd.prop('contenteditable', true);
}


//function selectedticketbug()
//{
//    debugger;
//    var selectedTd = $('table').find('tbody').find('tr').closest('td').text();
//    window.alert(selectedTd);
//}

function saveAllTicketDetails() {

    var selectedData = $('table').find('tbody').find('tr').has("input[type='checkbox']:checked");

    $.each(selectedData, function (i, value) {
        var ticketId = value;
    });

    //selectedTd.css('background-color', '#ffffff');
    //selectedTd.prop('contenteditable', false);

    //var releaseDesc = document.getElementById('relname').value;
    //if (releaseDesc == "") {
    //    alert("Please select atleast one ticket to update");
    //}
    //else {
    debugger;
    $.ajax({

        type: 'POST',
        url: '@Url.Action("saveAlTicketDetails", "Home")',
        dataType: 'json',
        data: {},
        success: function (data) {
            alert('Test1');
        },
        error: function (ex) {
            alert('HiEx');
            console.log(ex);
        }
    });
    //}
}