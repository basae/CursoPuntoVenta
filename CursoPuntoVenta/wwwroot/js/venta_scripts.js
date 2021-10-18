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
    $("#btn_agregar_producto").on("click", function () {
        $("#tbl_lista_productos tbody").append(
            '<tr>' +
            '<td><select class="form-control Nombre"><option value="">Selecciona un producto</option></select></td>' +
            '<td><input type="number" class="form-control cantidad" /></td>' +
            '<td><input type="number" class="form-control subtotal" disabled="disabled" /></td>' +
            '</tr>'
        );
        $.each(ProductosJson, function (index, obj) {
            $("#tbl_lista_productos tbody tr").last().find("select").append(
                '<option value="' + obj.id +'" data-precio="'+obj.Precio+'">'+obj.Nombre+'['+obj.Precio+'"]</option>'
            )
                
        });
        $("#tbl_lista_productos tbody tr").last().find(".cantidad").on("change", function () {
            var parent = $(this).closest("tr");
            if (parent.find("select").val() != "") {
                var precio = parent.find("select option:selected").attr("data-precio");
                var cantidad = $(this).val();
                parent.find(".subtotal").val(cantidad * precio);

                $.ajax(
                    {
                        url: "./Venta/AgregaProducto",
                        method: "POST",
                        contentType:"application/json",
                        data:JSON.stringify( {
                            Producto: {
                                id: parent.find("select").val(),                                
                            },
                            cantidad: cantidad
                        }),
                        success: function (respuesta) {
                            alert(JSON.stringify(respuesta));
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
});