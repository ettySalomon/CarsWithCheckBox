$(() => {

    console.log('hello world')
    $("input").on('input', function () {
        ensureFormValidity();
    })

    $("#car-type").on('change', function () {
        checkForSupercar();
        ensureFormValidity();
    });    

    
    function checkForSupercar() {
        const type = Number($("#car-type").val());
        if (type === 2) {
            $("#has-leather-seats").prop('checked', true);
            $("#has-leather-seats").prop('disabled', true);
            $("form").append("<input type= 'hidden' name='hasLeatherSeats' value='true' id='check-hidden' />");
        }
        else {
            $("#has-leather-seats").prop('disabled', false);
            $("#check-hidden").remove();
        }
    }
        

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