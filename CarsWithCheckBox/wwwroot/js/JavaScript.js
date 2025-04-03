$(() => {

    console.log('hello world')
    $("input").on('input', function () {
        ensureFormValidity();
    })

    $("#car-type").on('change', function () {
        ensureFormValidity();
    });

    //$("#age").on('input', function () {
    //    const age = Number($("#age").val());
    //    if (age > 50) {
    //        $("#signup").prop('checked', true);
    //        $("#signup").prop('disabled', true);
    //        $("form").append("<input type='hidden' name='signuptonewsletter' value='true' id='chk-hidden' />");
    //    }
    //    else {
    //        $("#signup").prop('disabled', false);
    //        $("#chk-hidden").remove();
    //    }
    //});

    function ensureFormValidity() {
        const make = $("#make").val().trim();
        const model = $("#model").val().trim();
        const year = $("#year").val().trim();
        const price = $("#price").val().trim();

        const isMakeValid = Boolean(make);
        const isModelValid = Boolean(model);

        const yearNum = Number(year);
        const isYearValid = Boolean(yearNum) && !isNaN(yearNum)
        const priceNum = Number(price);
        const isPriceValid = Boolean(priceNum) && !isNaN(priceNum)


        const carTypeValid = Number($("#car-type").val());


        const isFormValid = isMakeValid && isModelValid && isYearValid && isPriceValid && carTypeValid !== -1;
        $("#submit-button").prop('disabled', !isFormValid);
    }

   
})