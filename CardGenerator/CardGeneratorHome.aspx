<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/CardGenerator - FC Mobile.Master" AutoEventWireup="true" CodeBehind="CardGeneratorHome.aspx.cs" Inherits="CardGenerator.CardGeneratorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Image ID="imgImagen" runat="server" />
    
 <!-- SECCION PARA EL CONTENIDO -->



<!--BEGIN MODAL--->
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header" style="background-color:#55cca2">
        <h5 class="modal-title poppins-bold" id="exampleModalLabel" style="color:black"> Select Nation </h5>
      </div>
      <div class="modal-body poppins-semibold">
        <asp:TextBox ID="txtSearchNation" runat="server" placeholder="Search Nation" CssClass="form-control" onkeyup="filtrerNations()"/>
        <asp:DropDownList ID="ddlNation" runat="server" CssClass="form-control poppins-semibold TextGreen" onchange="uploadNation()">
        </asp:DropDownList>
          <div id="errorMessage" class="errorMessage contenedorCentradoHV" style="display:none;" ></div>
      </div>
    </div>
  </div>
</div>

<div class="modal fade" id="ModalLeague" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-bs-backdrop="static">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header" style="background-color:#55cca2">
        <h5 class="modal-title poppins-bold" id="ModalLeagueTitle" style="color:black"> Select League </h5>
      </div>
      <div class="modal-body poppins-semibold">
    <!--    <asp:TextBox ID="txtSearchLeague" runat="server" placeholder="Search League" CssClass="form-control" onkeyup="filtrerNations()"/> -->
        <asp:DropDownList ID="ddlLeague" runat="server" CssClass="form-control poppins-semibold TextGreen" onchange="uploadLeague()">
        </asp:DropDownList>
      </div>
    </div>
  </div>
</div>


<!--END MODAL-->

    <div class="bodyBlur">
    <section class="contenedorCentradoH">
        <div class="content-body-body">
            <div class="body-header">
                <div class="texto-body">
                    <h1 class="poppins-bold"> FC Mobile card generator </h1>
                    <p class="poppins-light"> Design and personalize your FC Mobile cards. </p>
                </div>
            </div>

            <div class="body-body">
            <div class="bodyContent ">
             <h1 class="poppins-bold contenedorCentradoV">Design your FC Mobile card</h1>   
             <div class="bodyContent-body">
                <div class="CardGenerator">
                    <div class="CardDefault contenedorCentradoHV">
                        <img id="card" runat="server" class="imgCard contenedorCentradoHV" src="IMAGENES/CardGenerator.png" alt="CardGeneratorDefault">
                        <img id="renderzimg" runat="server" class="imgCard1 contenedorCentradoHV" src="IMAGENES/RenderzCardDefault.png" alt="CardGeneratorDefault">
                        <img id="imgNatioDefault" runat="server" class="imgCard2 contenedorCentradoHV" src="IMAGENES/Brasil.png" alt="CardGeneratorDefault" onchange="changeModalLabel()">
                        <img id="imgLeagueDefault"  runat="server" class="imgCard3 contenedorCentradoHV" src="IMAGENES/LeagueCardDefault.png" alt="CardGeneratorDefault">
                        <img class="imgCard4 contenedorCentradoHV" runat="server" src="IMAGENES/TeamCardDefault.png" alt="CardGeneratorDefault">
                        <div class="LabelNombreCont imgCard5">
                      
                        <asp:Label ID="lblName" runat="server" Text=" VINI JR " CssClass="NameCard txtColorD"></asp:Label>
                        </div>
    
                        <asp:Label ID="lblOVR" runat="server" Text=" 89 " CssClass="OVRCard imgCard6 txtColorD"></asp:Label>

                        <asp:Label ID="lblPos" runat="server" Text=" EI " CssClass="POSCard imgCard7 txtColorD"></asp:Label>
                    </div>
                    <div class="ButtonD-Con contenedorCentradoH">
                        <button id="Download"type="button" class="btn-download"> Download </button>
                    </div>
                </div>
                   <div class="FormCard ">

                    <div class="textLeft">
                        <div class="card-desing">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                       
                                      <label for="campo1" class="poppins-semibold textLeft"> Card Version <i class="fa-solid fa-circle-down" style="color: #55cca2;"></i> </label>                                     
                                         <asp:DropDownList ID="ddlBackgrounds" runat="server" CssClass="form-control poppins-semibold" onchange="uploadCard(this)"></asp:DropDownList>
                                    </div>
                                </div>
                    
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="campo1" class="poppins-semibold textLeft"> Load Render  </label> 
                                        <label class="btn-download form-control" for="UploadButton1" style="background-color: #55cca2; text-align:center"> Upload Image <i class="fa-solid fa-upload" style="color: #000000;"></i></i> </label>
                                   <!--     <button id="UploadButton" class="btn-download form-control" style="background-color: #55cca2;"> Upload File <i class="fa-solid fa-upload" style="color: black solid #000;;" ></i> </button> -->
                                        <input type="file" id="UploadButton1" class="btn-download form-control" style="background-color: #55cca2; display:none;" onchange="uploadImage(this)" />
                                    </div>
                                </div>
                        </div>
                    </div>

                    
                    
                    <div class="textLeft">
                        <div class="config-image-size">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="campo1" class="poppins-semibold textLeft"> Position:  </label> 
                                </div>
                            </div>
                    
                    
                            <div class="row">        
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <button id="btnIzquierda" class="btn-izquierda form-control" style="background-color: #55cca2;" > Left <i class="fa-solid fa-left-long" style="color: #000000;"></i></button>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <button id="btnArriba" class="btn-arriba form-control" style="background-color: #55cca2;" > Top <i class="fa-solid fa-arrow-up" style="color: #000000;"></i> </button>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <button id="btnAbajo" class="btn-abajo form-control" style="background-color: #55cca2;" > Down <i class="fa-solid fa-arrow-down" style="color: #000000;"></i></button>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <button id="btnDerecha" class="btn-derecho form-control" style="background-color: #55cca2;" > Right <i class="fa-solid fa-right-long" style="color: #000000;"></i></button>
                                    </div>
                                </div>
                    
                    
                        </div>
                    </div>

                    <div class="textLeft">
                        <div class="size-img">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="campo1" class="poppins-semibold textLeft"> Size:  </label> 
                                </div>
                            </div>
                    
                    
                            <div class="row">        
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <button id="btnAumentar" class="btn-izquierda form-control" style="background-color: #55cca2;" > Increase <i class="fa-solid fa-magnifying-glass-plus" style="color: #000000;"></i> </button>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <button id="btnReducir" class="btn-arriba form-control" style="background-color: #55cca2;" > Decrease <i class="fa-solid fa-magnifying-glass-minus" style="color: #000000;"></i> </button>
                                    </div>
                                </div>
                        </div>
                    </div>

                    <div class="textLeft">
                        <div class="info-personal">
                            <div class="row">
                                <div class="col-sm-7">
                                    <div class="form-group">
                                       
                                        <label for="campo1" class="poppins-semibold textLeft">Name Player</label>                                   
                                         <asp:TextBox ID="txtName" runat="server" CssClass="form-control poppins-semibold" onchange="uploadLabelNombre(this)" onkeypress="return event.keyCode != 13;"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="campo1" class="poppins-semibold textLeft"> OVR </label>
                                        <asp:TextBox ID="txtOVR" runat="server" CssClass="form-control poppins-semibold" onchange="uploadLabelOVR(this)" onkeypress="return event.keyCode != 13;"></asp:TextBox>  
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="campo1" class="poppins-semibold textLeft"> POS </label>
                                        <asp:TextBox ID="txtPOS" runat="server" CssClass="form-control poppins-semibold" onchange="uploadLabelPOS(this)" onkeypress="return event.keyCode != 13;"></asp:TextBox>
                                      
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="textLeft">
                        <div class="text-edition">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="colorPicker" class="poppins-semibold textLeft" > Select text color: </label>
                                        <input type="color" id="colorPicker" class="form-control poppins-semibold">
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label for="colorPicker" class="poppins-semibold textLeft" > Change color </label>
                                        <button id="ChangeColorText" class="btn-change-text form-control contenedorCentradoV" style="background-color: #55cca2;"> Change Color </button>
                                    </div>
                                </div>
                        </div>
                    </div>

<div class="textLeft">
    <div class="player-info">
        <div class="row">
            <div class="col-sm-6">
                  <label for="campo1" class="poppins-semibold textLeft"> Nation <i class="fa-solid fa-flag" style="color: #55cca2;"></i> </label>
            <!--    <di class="form-group"> -->
                    <div class="form-control bg-custom" id="ModalActivate" data-bs-toggle="modal" data-bs-target="#exampleModal" >

                        <div class="row contenedorCentradoV ">
                        <div class="col-sm-8">
                        <asp:Label ID="lblNationsTextSleeted" runat="server" Text=" Aqui va el nombre " CssClass="poppins-semibold textLeft "></asp:Label>
                         </div>
                        <div class="col-sm-4">
                        <asp:Image ID="imgNation" runat="server" ImageUrl="~/IMAGENES/Ecuador.png" AlternateText="Nation" Width="25px" Height="25px"/>

                        </div>
                        </div>
                        </div>
                </div>

             <div class="col-sm-6">
     <div class="form-group">
         <label for="campo1" class="poppins-semibold textLeft"> League <i class="fa-solid fa-shield" style="color: #55cca2;" ></i> </label> 
                             <div class="form-control bg-custom" id="ModalLeagues" data-bs-toggle="modal" data-bs-target="#ModalLeague">

                        <div class="row contenedorCentradoV ">
                        <div class="col-sm-9">
                        <asp:Label ID="lblLeagueSelect" runat="server" Text="" CssClass="poppins-semibold textLeft "></asp:Label>
                         </div>
                        <div class="col-sm-3">
                        <asp:Image ID="imgLeagueSelect" runat="server" ImageUrl="~/IMAGENES/Ecuador.png" AlternateText="Nation" Width="25px" Height="25px"/>

                        </div>
                        </div>
                        </div>
     </div>
 </div>
            </div>

        <div class="row">
         <div class="col-sm-12">
     <div class="form-group">
         <label for="campo1" class="poppins-semibold textLeft"> Team <i class="fa-solid fa-shield-dog" style="color: #55cca2;"></i></label>
         <input type="text" class="form-control poppins-semibold"">
     </div>
 </div>
            </div>
           
    </div>
</div>

<div class="aplyChangeCont contenedorCentradoHV">
    <div class="form-group ">    
        <asp:Button ID="btnAplychange" runat="server" Text=" Apply changes " CssClass="btn-aplyChange form-control" style="background-color: #55cca2;" OnClick="btnAplychange_Click"  />
    </div>
</div>



                </div>
             </div>
            </div>
            
            </div>

        </div>

               

    </section>
    <asp:HiddenField id="lblNationText" runat="server" Value="Brazil"/>
    <asp:HiddenField ID="lblLeagueText" runat="server" Value="LA LIGA EA SPORTS" />
    <asp:HiddenField ID="urlImagehtml2" runat="server" Value=""/>
        <asp:HiddenField ID="apiKey" runat="server" Value="8HCAdU7MjfrU59taNVBv7P5j"/>

 </div>
                    
</div>
    </div>
</asp:Content>
