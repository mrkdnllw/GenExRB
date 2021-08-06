console.log("this is a test");

$("#clearbtn").click(function () {
    console.log("clear button is clicked");

    $("#keywordfield").val(''); //clears the keyword field

    $('#selection1').prop('selectedIndex', 0);
    $('#selection2').prop('selectedIndex', 0);
    $('#selection3').prop('selectedIndex', 0);
    $('#selection4').prop('selectedIndex', 0);
});