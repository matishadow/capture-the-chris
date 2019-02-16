$(document).ready(function() {
    var slider = $("#passwordRange");
    var output = $("#lengthValue");
    output.val(slider.val());

    slider.on("input",
        function() {
            output.val(slider.val());
        });
    output.on("input",
        function () {
            slider.val(output.val());
        });
});