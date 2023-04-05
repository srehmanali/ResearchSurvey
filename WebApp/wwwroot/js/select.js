$(document).ready(function () {
    $('select').select2({
        dropdownCssClass: "select-dropdown-css",
        selectionCssClass: "select-dropdown-css",
        height: "100px"
    });
    $("select").on("select2:select", function (evt) {
        var element = evt.params.data.element;
        var $element = $(element);

        $element.detach();
        $(this).append($element);
        $(this).trigger("change");
    });
})