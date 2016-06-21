$(function () {

    $.getJSON("/Salas/salas", function (data) {
        var items = "<option value='"+"-1'> Seleccione Sala </option>";
        $.each(data, function (i, sala) {
            items += "<option value='" + sala.Value + "'>" + sala.Text + "</option>";
        });
        $("#SalaId").html(items);
    });

    $("#SalaId").change(function() {
        $.getJSON("/Reportes/equipos/"+$("#SalaId > option:selected").attr("value"), function (data) {
            var items ;
            $.each(data, function (i, equipo) {
                items += "<option value='" + equipo.Value + "'>" + equipo.Text + "</option>";
            });
            $("#EquipoId").html(items);
        });
    });
});