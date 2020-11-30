function aparecelogin() {
    event.preventDefault();
    $("#login").animate({
        'top': '0'
    }, 500);
}
function desaparecelogin() {
    event.preventDefault();
    $("#login").animate({
        'top': '-100'
    }, 500);
}
function desaparecerRegistro() {
    $("#oscurecer").fadeOut();
}

function desaparecerFormulario() {
    $("#registrar").fadeOut(300, desaparecerRegistro);
}
function MostrarFormulario(){
    $("#registrar").fadeIn();
    $("#oscurecer").click(desaparecerFormulario);
    $("#cerrarRegistro").click(desaparecerFormulario);
}
function apareceRegistro(e){
    e.preventDefault();
    $("#oscurecer").fadeIn(500, MostrarFormulario);
}
function mostrarLoginYRegistro() {
    $("#activarLogin").click (aparecelogin);
    $("#cerrar").click (desaparecelogin);

    $("#activarRegistro").click(apareceRegistro);
}
$(document).ready (mostrarLoginYRegistro);