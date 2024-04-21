// Creamos evento al boton Donwload 
$("#Download").on('click', function(){
    // Lllamamos a la funcion para descagar la imagen
    DownloadImage();
})

var elemento;
// Funcion DownloadImage();
function DownloadImage(){
    //Crear el elemto completo a descargar las cosas
   elemento = $('.CardDefault')[0];

   html2canvas(elemento).then(function(canvas){
    // En este paso definimos que vamos hacer una imagen/png 
    var ImagenURL = canvas.toDataURL("image/png");
    var enlaceDescarga = document.createElement('a');
    enlaceDescarga.href = ImagenURL;
    enlaceDescarga.download = 'imagen_personalizada.png'; // Nombre de archivo para la descarga
    document.body.appendChild(enlaceDescarga);

    // Simular clic en el enlace para iniciar la descarga
    enlaceDescarga.click();

    // Limpiar después de la descarga
    document.body.removeChild(enlaceDescarga);
   })
}

$("#ChangeColorText").on('click', function(e){
    e.preventDefault();
    ChangeColorText();
})

var colorText;
// SECCION PARA CAMBIAR EL COLOR DE LOS TEXTOS 
function ChangeColorText(){

    //Obtenemos el color seleccionado
    colorText = $("#colorPicker").val();

    //Aplicamos este color a los labels con la clase
    $('.txtColorD').css('color', colorText);

}

$("#btnIzquierda").on('click', function(e){
    e.preventDefault();
    ChangePositionLeft();
})

$("#btnArriba").on('click', function(e){
    e.preventDefault();
    ChangePositionTop();
})

$("#btnAbajo").on('click', function(e){
    e.preventDefault();
    ChangePositionDown();
})

$("#btnDerecha").on('click', function(e){
    e.preventDefault();
    ChangePositionRight();
})

$("#btnAumentar").on('click', function(e){
    e.preventDefault();
    PlusSizeImg();
})

$("#btnReducir").on('click', function(e){
    e.preventDefault();
    LessSizeImg();
})

function ChangePositionLeft(){
    $(".imgCard1").css("right", "+=2px");
}

function ChangePositionTop(){
    $(".imgCard1").css("top", "-=2px");
}

function ChangePositionDown(){
    $(".imgCard1").css("top", "+=2px");
}

function ChangePositionRight(){
    $(".imgCard1").css("right", "-=2px");
}

function PlusSizeImg(){
    $(".imgCard1").css("width", "+=2px");
}

function LessSizeImg(){
    $(".imgCard1").css("width", "-=2px");
}


$("#btnAplychange").on('click', function(){
    //Llamamos a los metodos 
    ChangeColorText();
})

// Funcion para subir el archivo
var Files;
var FilesType;
function uploadImage(input) {
    if (input.files && input.files[0]){
        Files = input.files[0]
        FilesType = Files.type;

        if (FilesType.startsWith('image/')) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#renderzimg').attr('src', e.target.result);
            }
            reader.readAsDataURL(Files);
        } else {
            alert("Please select an image file.");
        }

    };
}

// Funcion para actualizar nombres dinamicamente

var txtName;
function uploadLabelNombre(data) {

    txtName = $("#txtName").val();
    console.log(txtName);
    $("#lblName").text(txtName);
}

var txtOVR;
function uploadLabelOVR(e) {

    txtOVR = $("#txtOVR").val();
    console.log(txtOVR);
    $("#lblOVR").text(txtOVR);
}

var txtPOS;
function uploadLabelPOS(e) {
    txtPOS = $("#txtPOS").val();
    console.log(txtPOS);
    $("#lblPos").text(txtPOS);
}

var ddCard;
function uploadCard(e) {
    ddCard = $("#ddlBackgrounds").val();
    $("#card").attr("src", ddCard)
}


var Nation;
var NationText;
function uploadNation() {
    // Asigno un variable el valor seleccionado del ddl
    Nation = $("#ddlNation").val();
    // Asigno a una variable el valor del text seleccionado del ddl
    NationText = $("#ddlNation option:selected").text();
    // le asginfo a imgNation default la nueva bandera
    $("#imgNatioDefault").attr("src", Nation);
    // Asigno el Tetxo d ela nacion seleccionada a un hidden,filed;
    $("#lblNationText").val(NationText);
    console.log($("#lblNationText").val());

    // Ahora asiganmos estos valores a otro conjunto de datos;

    $("#imgNation").attr("src", Nation);
    $("#lblNationsTextSleeted").text(NationText);

    //Crerramos el modal
    $("#exampleModal").modal('hide');
    $('.bodyBlur').removeClass('blur')
}

var League;
var LeagueText;
function uploadLeague() {
    //Lo primero es absorver los valores del option seleccionado;
    League = $("#ddlLeague").val();
    LeagueText = $("#ddlLeague option:selected").text();
    $("#imgLeagueDefault").attr("src", League);
    $("#lblLeagueText").val(LeagueText);

    // Ahora asiganmos estos valores a otro conjunto de datos;

    $("#imgLeagueSelect").attr("src", League);
    $("#lblLeagueSelect").text(LeagueText);

    //Crerramos el modal
    $("#ModalLeague").modal('hide');
    $('.bodyBlur').removeClass('blur')


}

var TextSearch;
var ddlNation;
var DelayTimer;



function filtrerNations() {
    clearTimeout(DelayTimer);
    TextSearch = $("#txtSearchNation").val();
    ddlNation = $("#ddlNation");
    console.log("el texto filtrado es:", TextSearch);

    if (TextSearch.empty) {
        ddlNation.show();
    }
    // Limpiamos el ddl;
    ddlNation.empty();

    DelayTimer = setTimeout(function () {
        var objAJAXFIL;
        // Hacemos la solicitud AJAX 
        objAJAXFIL = JSON.stringify({ text: TextSearch });
        console.log(objAJAXFIL);
        $.ajax({
            type: "POST",
            url: "CardGeneratorHome.aspx/JsonResponse",
            data: objAJAXFIL,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Limpiar el DropDownList
                ddlNation.empty();

                if (response.d.length === 0) {
                    var errorMessage = "No se encontraron resultados    ";
                    var errorMessage2 = $("#errorMessage");
                    errorMessage2.attr("style", "display:flex");
                    var span = $("<span>").text(errorMessage).addClass("errorMessageSpan");
                    var icon = $("<i>").addClass("fa-solid fa-circle-exclamation").css("color", "#63E6BE");
                    span.append(icon);
                    errorMessage2.empty().append(span);
                    ddlNation.hide();
                } else {
                    // Llenar el DropDownList con las opciones filtradas
                    var errorMessage2 = $("#errorMessage");
                    errorMessage2.attr("style", "display:none");
                    response.d.forEach(function (item) {
                        ddlNation.append($("<option></option>").attr("value", item.NationUrl).text(item.Nations));
                        ddlNation.attr("placeholder", item.Nation);
                    });

                    // Forzar la selección de la primera opción si solo hay una
                    if (response.d.length === 1) {
                        ddlNation.val(ddlNation.find('option:first').val());
                        uploadNation();
                    }

                    // Establecer un tamaño máximo del menú desplegable
                    ddlNation.attr("size", response.d.length > 10 ? 10 : response.d.length);

                    // Mostrar el menú desplegable
                    ddlNation.show();
                }
            }
        });
    }, 500);
}

 
// ACTIVAMOS EL MODAL

$("#ModalActivate").on('click', function () {
    // Esto detecta un click dentro del contenedor 
    $("#exampleModal").modal('show');
    $('.bodyBlur').addClass('blur');
})

$("#ModalLeagues").on('click', function () {
    // Esto detetcta un click en el conjunto con id modalleague;
    $("#ModalLeague").modal('show');
    $('.bodyBlur').addClass('blur');
})
