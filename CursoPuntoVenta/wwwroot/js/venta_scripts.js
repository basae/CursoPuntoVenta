$(function () {
    $("#btn_terminar_venta").on("click", function (event) {
        event.preventDefault();
        if ($("#Id_empleado").val() == "") {
            alert("debes seleccionar un empleado");
        }
        else {
            $("#form1").submit();
        }
    });
    $(".cantidad").on("change", function () {
        var parent = $(this).closest("tr");
        if (parent.find("select").val() != "") {
            var precio = parent.find("select option:selected").attr("data-precio");
            var cantidad = $(this).val();
            parent.find(".subtotal").val(cantidad * precio);
        }
        else {
            alert("selecciona un producto primero bestia");
        }

    });
});