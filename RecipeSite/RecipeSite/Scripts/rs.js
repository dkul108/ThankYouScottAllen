$(function () {
    
    var ajaxFormSubmit = function () {
        //grap a reference to form being submitted
        var $form = $(this);
        //build object to store action url and method type and store them as key value pairs
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
        };

        //make async call to server and what to do when it is done
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-rs-target"));
            $target.replaceWith(data);
        });

        //prevent browser from default action of going to server and redrawing page
        return false;
    };

    //go find all the forms that have this attribute and instead of going to server on submit, it will go to ajaxFormSubmit
    $("form[data-rs-ajax='true']").submit(ajaxFormSubmit);
});