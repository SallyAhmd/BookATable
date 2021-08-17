"use strict"

$(document).ready(function () {


    $(".saveBooking").click(function () {

       var bookName = $("#bookName").val().trim();
        var address = $("#address").val().trim();
        var number = $("#number").val().trim();
        var bDate = $("#datepicker").val().trim();
        var fTime = $("#fTime").val();
        var tTime = $("#tTime").val();
        var ddlqty = $("#ddlTable").val();

        SendData(bookName, address, number, bDate, fTime, tTime, ddlqty);
        
        //var bookName = $("#bookName").text;
    });


    $(".bAreaView").hide();
    $(".bStatusView").hide();

    $(".bArea").click(function () {
        $(".bAreaView").show();
        $(".bStatusView").hide();
    });

    $(".bStstus").click(function () {
        $(".bAreaView").hide();
        $(".bStatusView").show();
    });

});



$(function () {
    $("#datepicker").datepicker();
});
function SendData(bookName, address, number, bDate, fTime, tTime, ddlqty) {
    
    $.ajax({
        type: "POST",
        url: "CustPage.aspx/SaveBooking", 
        //data: dataToSend,
        data: JSON.stringify({ BookinName: bookName, Add: address, Phone: number, bookingDate: bDate, From: fTime, To: tTime, qty: ddlqty}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

            if (msg.d != undefined) {
                $("#bookName").val('');
                $("#address").val('');
                $("#number").val('');
                $("#datepicker").val('');
                $("#fTime").val('');
                $("#tTime").val('');
                $(".bAreaView").hide();
                $(".bStatusView").show();
            }

           
        }
    });
}

