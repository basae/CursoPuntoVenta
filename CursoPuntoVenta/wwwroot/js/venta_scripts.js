
$(function () {
    var ListaVenta = [];
    var beforeCantidad = 0;
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
    $("#btn_agregar_producto").on("click", function () {

        $("#tbl_lista_productos tbody").append(
            '<tr>' +
            '<td><select class="form-control Nombre"><option value="">Selecciona un producto</option></select></td>' +
            '<td><input type="number" class="form-control cantidad" /></td>' +
            '<td><input type="number" class="form-control subtotal" disabled="disabled" /></td>' +
            '<td><button type="button" class="btn btn_eliminar_producto"><i class="bi bi-cart-dash" style="font-size:40px;"></i></td>' +
            '</tr>'
        );
        $.each(ProductosJson, function (index, obj) {
            $("#tbl_lista_productos tbody tr").last().find("select").append(
                '<option value="' + obj.id + '" data-precio="' + obj.Precio + '">' + obj.Nombre + '[' + obj.Precio + '"]</option>'
            )
        });
        $("#tbl_lista_productos tbody tr").last().find(".cantidad").keypress(function (event) {
            beforeCantidad = parseInt($(this).val());
        });
        $("#tbl_lista_productos tbody tr").last().find(".btn_eliminar_producto").on("click", function () {
            var parent = $(this).closest("tr");
            actualizaObj();
            $.ajax(
                {
                    url: "./Venta/QuitarProducto?id_producto=" + parent.find("select").val(),
                    method: "POST",
                    contentType: "application/json",
                    data: JSON.stringify({
                        Productos: ListaVenta
                    }
                    ),
                    success: function (respuesta) {
                        if (respuesta.error) {
                            alert(respuesta.message);
                        }
                        else {
                            parent.remove();
                            $("#Subtotal").val(respuesta.result.subtotal);
                            $("#IVA").val(respuesta.result.iva);
                            $("#Total").val(respuesta.result.total);
                        }
                    },
                    error: function (err) {
                        alert(err)
                    }
                });
        });
        $("#tbl_lista_productos tbody tr").last().find(".cantidad").on("change", function () {
            var parent = $(this).closest("tr");
            if (parent.find("select").val() != "") {                                              
                $.ajax(
                    {
                        url: "./Venta/AgregaProducto?id_producto=" + parent.find("select").val() + "&cantidad=" + cantidad + "&cantidadAntesCambio=" + beforeCantidad,
                        method: "POST",
                        contentType: "application/json",
                        data: JSON.stringify({
                            Productos: ListaVenta                            
                        }
                        ),
                        success: function (respuesta) {
                            if (respuesta.error) {
                                alert(respuesta.message);
                            }
                            else {
                                $("#Subtotal").val(respuesta.result.subtotal);
                                $("#IVA").val(respuesta.result.iva);
                                $("#Total").val(respuesta.result.total);
                            }
                        },
                        error: function (err) {
                            alert(err)
                        }
                    });
            }
            else {
                alert("selecciona un producto primero bestia");
            }

        });

    });
    function actualizaObj() {
        ListaVenta = [];
        $.each($("#tbl_lista_productos tbody tr"), function (i, o) {
            ListaVenta.push({
                Producto: {
                    Id: $(this).closest("tr").find("select").val()
                },
                cantidad: $(this).closest("tr").find(".cantidad").val()
            })
        });
    }
});