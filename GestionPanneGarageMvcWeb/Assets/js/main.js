
$(function () {
    $('.categorie_id').on('change', function () {
        var id = $(this).val();
        //alert(id);
        $.get('/Reparations/getProducts', { id: id }, function (data) {
            $('.product_id').empty();
            $('.product_id').append("<option value=''>select a categorie Articles</option>")
            $.each(data, function (index, row) {

                $('.product_id').append("<option value='" + row.Identification + "'>" + row.ArticleName + "." + row.Description + "</option>")
            });
        });
    });
});

$(function () {
    $('.product_id').on('change', function () {
        var product_id = $(this).val();
        //alert(product_id);
        $.get('/Reparations/getUnitPrice', { product_id: product_id }, function (data) {
            $('#unit_price').val(data.PrixUnitaire);
        });
    });
});

$(function () {
    $('#qty').on('keyup', function () {
        var qty = $(this).val();
        var unit_price = $('#unit_price').val();
        var total = qty * unit_price;
        $('#total').val(total);
    });
});
//$(function () {
//    $('.categorie_id').on('change', function () {
//        var id = $(this).val();
//        alert(id);
//        $.get('/Reparations/getDescriptionsVehicules', { id: id }, function (data) {
//            $('.typevehicule_id').empty();
//            $('.typevehicule_id').append("<option value=''>select a type vehicule</option>")
//            $.each(data, function (index, row) {

//                $('.typevehicule_id').append("<option value='" + row.Identification + "'>" + row.Description + "</option>")
//            });
//        });
//    });
//});

//print details
//$(function () {
//    $('#print').on('click', function () {
//        window.print();
//        return false;
//    });
//});
//paiement
//$(function () {
//    $('.reparation_id').on('change', function () {
//        var reparation_id = $(this).val();
//        alert(reparation_id);
//        $.get('/Paiements/getTotalReparations', { reparation_id: reparation_id }, function (data) {
//            $('#montanttotal').val(data.Total);
//        });
//    });
//});
//$(function () {
//    $('#MontantTotalPaye').on('keyup', function () {
//        var MontantTotalPaye = $(this).val();
//        var montanttotal = $('#montanttotal').val();
//        var total = montanttotal - MontantTotalPaye;
//        $('#MontantRestant').val(total);
//    });
//});