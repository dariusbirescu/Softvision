$(document).ready(function () {
    var UpdateResources = function () {
        updateResource("Clay");
        updateResource("Wheat");
        updateResource("Iron");
        updateResource("Wood");
    };
    var updateResource = function (resourceName) {
        var start = new Date();
        var currentProduction = 0;
        var currentValue = parseFloat($(".res-value." + resourceName).text());
        var lastUpdate = Date.parse($(".res-update." + resourceName).text());

        var mines = $(".mines").find("." + resourceName);
        $.each(mines, function (index, value) {
            currentProduction += parseInt($(value).find(".hourProduction").text());
        });
        var nextValue = (currentValue + (start.getTime() - lastUpdate) / 1000 / 60 / 60 * currentProduction);

        $(".res-value." + resourceName).text(nextValue);
        $(".res-update." + resourceName).text(start.strftime("%Y-%m-%d %H:%M:%S"));
    };

    setInterval(UpdateResources, 500);

    $('#mine-details-container > .close-btn').click(function () {
        $('#mine-details-container').removeClass('show');
    });

    var getMineDetailsHTML = function (mineID) {
        $('#mine-details-container > .content').empty();
        $('#mine-details-container > .content').load("/Mines/Details?mineID=" + mineID);
        $('#mine-details-container').addClass('show');
    };

    $('.mine-details-btn').click(function (e) {
        var mineID = $(this).data('mine-id');
        getMineDetailsHTML(mineID);
        console.log('log');
    });
});