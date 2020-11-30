$(document).ready(function () {

    //agregar clase active al primer enlace ======
    $('.category_list .category_item[category="all"]').addClass('ct_item-active');
    $('.category_item').click(function () {
        var catProduct = $(this).attr('category');

        //agregando clase active al enlace seleccionado
        $('.category_item').removeClass('ct_item-active');
        $(this).addClass('ct_item-active');

        //ocultando productos
        $('.products-item').css('transform', 'scale(0)');
        function hideProduct(){
            $('.products-item').hide();
        } setTimeout(hideProduct,400);
        

        //Mostrando productos 
        function showProduct() {
            $('.products-item[category="' + catProduct + '"]').show();
            $('.products-item[category="' + catProduct + '"]').css('transform', 'scale(1)')
        } setTimeout(showProduct, 400);
       

        //Mostrando todos los productos
        $('.category_item[category="all"]').click(function () {
            function showAll(){
                $('.products-item').show();
                $('.products-item').css('transform', 'scale(1)');
            } setTimeout(showAll, 400);
           
        });
    });

});