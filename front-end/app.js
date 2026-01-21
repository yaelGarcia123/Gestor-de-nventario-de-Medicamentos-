const API_URL = "https://localhost:7231/api/medicamentos"; 

$(document).ready(function() {
    listarMedicamentos();

    // 1. Filtro por Nombre (Búsqueda en tiempo real)
    $('#buscarNombre').on('keyup', function() {
        listarMedicamentos($(this).val(), $('#filtroCategoria').val());
    });

    // 2. Filtro por Categoría
    $('#filtroCategoria').on('change', function() {
        listarMedicamentos($('#buscarNombre').val(), $(this).val());
    });

    // 3. Guardar/Actualizar
    $('#medForm').submit(function(e) {
        e.preventDefault();
        const id = $('#medId').val();
        const data = {
            nombre: $('#nombre').val(),
            categoria: $('#categoria').val(),
            cantidad: parseInt($('#cantidad').val()),
            fecha_expiracion: $('#fecha').val()
        };

        const tipo = id ? 'PUT' : 'POST';
        const urlFinal = id ? `${API_URL}/${id}` : API_URL;
        if(id) data.id = parseInt(id);

        $.ajax({
            url: urlFinal,
            type: tipo,
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function() {
                alert("Operación exitosa");
                limpiarFormulario();
                listarMedicamentos();
            }
        });
    });
});

// Función Maestra para Listar y Filtrar
function listarMedicamentos(nombre = "", categoria = "") {
    // Construimos la URL con parámetros de búsqueda
    let url = `${API_URL}?nombre=${nombre}&categoria=${categoria}`;

    $.get(url, function(res) {
        let rows = '';
        res.forEach(m => {
            // Validación para evitar el error 'split of undefined'
            let fechaParaInput = m.fecha_expiracion ? m.fecha_expiracion.split('T')[0] : "";
            let fechaMostrar = m.fecha_expiracion ? new Date(m.fecha_expiracion).toLocaleDateString() : "N/A";

            rows += `
            <tr>
                <td>${m.nombre}</td>
                <td><span class="badge bg-info text-dark">${m.categoria}</span></td>
                <td>${m.cantidad}</td>
                <td>${fechaMostrar}</td>
                <td>
                    <button class="btn btn-warning btn-sm" onclick="prepararEdicion(${m.id}, '${m.nombre}', '${m.categoria}', ${m.cantidad}, '${fechaParaInput}')">Editar</button>
                    <button class="btn btn-danger btn-sm" onclick="eliminar(${m.id})">Eliminar</button>
                </td>
            </tr>`;
        });
        $('#tablaMedicamentos').html(rows);
    });
}

function prepararEdicion(id, nombre, categoria, cantidad, fecha_expiracion) {
    $('#medId').val(id);
    $('#nombre').val(nombre);
    $('#categoria').val(categoria);
    $('#cantidad').val(cantidad);
    $('#fecha').val(fecha_expiracion);
    $('#btnGuardar').text("Actualizar Medicamento").removeClass("btn-success").addClass("btn-warning");
}

function limpiarFormulario() {
    $('#medId').val("");
    $('#medForm')[0].reset();
    $('#btnGuardar').text("Agregar Medicamento").removeClass("btn-warning").addClass("btn-success");
}

function eliminar(id) {
    if(confirm("¿Seguro que desea eliminar?")) {
        $.ajax({
            url: `${API_URL}/${id}`,
            type: 'DELETE',
            success: () => listarMedicamentos()
        });
    }
}