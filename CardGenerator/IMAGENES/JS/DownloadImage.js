// Creamos evento al boton Donwload 
$("#Download").on('click', function () {
    // Lllamamos a la funcion para descagar la imagen
    DownloadImage();
});

var elemento;
// Funcion DownloadImage();
function DownloadImage() {
    //Crear el elemto completo a descargar las cosas god
   elemento = $('.CardDefault')[0];
    html2canvas(elemento).then(function (canvas) {
        // Aqui creamos la url de de la imagen 
        var ImagenURL = canvas.toDataURL("image/png");
        // Almacenas esa url en un HiddenField oculto 
        // Hacemos la solitud al API Remove.bg
        var apiKey = $("#apiKey").val();
        removeBackgroundFromImage(apiKey, ImagenURL);
    });
};

// Funcion que hace la api solitud;
async function removeBackgroundFromImage(apiKey, imageUrl) {
    const formData = new FormData();
    formData.append("image_file_b64", imageUrl);
    formData.append("size", "auto");

    try {
        const response = await fetch("https://api.remove.bg/v1.0/removebg", {
            method: "POST",
            headers: {
                "X-Api-Key": apiKey
            },
            body: formData
        });

        if (response.ok) {
            const imageBlob = await response.blob();
            const reader = new FileReader();

            reader.onload = function () {
                const base64String = reader.result.split(",")[1];
                // Decodifica el string base64 a un array de bytes
                const byteCharacters = atob(base64String);

                // Convierte los bytes a un array tipo Uint8Array
                const byteNumbers = new Array(byteCharacters.length);
                for (let i = 0; i < byteCharacters.length; i++) {
                    byteNumbers[i] = byteCharacters.charCodeAt(i);
                }
                const byteArray = new Uint8Array(byteNumbers);

                // Crea un Blob a partir del array de bytes
                const blob = new Blob([byteArray], { type: 'image/png' });

                // Crea una URL para el Blob
                const imageUrl = URL.createObjectURL(blob);

                // Crea un enlace
                const downloadLink = document.createElement('a');
                downloadLink.href = imageUrl;
                downloadLink.download = 'CardGenertor.png'; // Puedes cambiar el nombre del archivo aquí

                // Haz clic en el enlace para iniciar la descarga
                downloadLink.click();

                // Libera la URL del Blob después de la descarga
                URL.revokeObjectURL(imageUrl);
                console.log("Background removed successfully!");
            };

            reader.readAsDataURL(imageBlob);
        } else {
            const errorText = await response.text();
            console.error("Error:", errorText);
        }
    } catch (error) {
        console.error("Error:", error);
    }
}

$("#ChangeColorText").on('click', function (e) {
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

// OnClick Event Close Modal Select Nation
$("#btn_Modal_Close").on('click', function (e) {
    e.preventDefault();
    $("#exampleModal").modal('hide');
    $('.bodyBlur').removeClass();
})
$("#btn_Modal_Close2").on('click', function (e) {
    e.preventDefault();
    $("#ModalLeague").modal('hide');
    $('.bodyBlur').removeClass();
})



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
