<%@ Page Title="" Language="C#" MasterPageFile="~/CardGenerator - FC Mobile.Master" AutoEventWireup="true" CodeBehind="AccountProfile.aspx.cs" Inherits="CardGenerator.AccountProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <!-- SECCION PARA EL CONTENIDO -->

    <section class="contenedorCentradoH">
        <div class="content-body-body">
            <div class="body-header">
                <div class="texto-body">
                    <h1 class="poppins-light"> My Account </h1>
                    <p class="poppins-bold title-perfil"> Welcome <asp:Label ID="lbluserName" runat="server" Text="" CssClass="TextGreen title-perfil"></asp:Label> </p>
                </div>
            </div>
                         <h1 class="poppins-bold contenedorCentradoV TextGreen" style="margin:20px"> CUSTOMIZE YOUR PROFILE </h1> 

            <div class="body-body">
            <div class="bodyContent ">
  
             <div class="bodyContent-body1">
                <div class="CardGenerator">
                    <div class="CardDefaultC contenedorCentradoHV">
                         <asp:ImageButton ID="imgProfile" runat="server" ImageUrl="" CssClass="imgCardP imgAccount2 contenedorCentradoHV" />
                      <!--   <img class="imgCard imgAccount2 contenedorCentradoHV" src="IMAGENES/AccountLogoDefault-removebg-preview.png" alt="CardGeneratorDefault">     -->      
                    </div>
                    <div class="textProfile">
                         <asp:Label ID="lblUsername2" runat="server" Text="" CssClass="TextGreen poppins-medium contenedorCentradoHV" ></asp:Label> 
                        </div>
                </div>
                   <div class="FormCard ">
                       <div class="texto-body">
    <h1 class="poppins-bold TextGreen"> Select your prefeer account avatar </h1>
   
</div>

   <div class="textLeft">
       <div class="card-desing">
           <div class="row">
               <div class="col-sm-12">
                 <div class="CardDefaultP contenedorCentradoHV">                
                        <asp:ImageButton ID="AccountLogo1" runat="server" src="IMAGENES/AccountLogo1.png" CssClass="imgAccount" OnClick="AccountLogo1_Click"  />                
                         <asp:ImageButton ID="AccountLogo2" runat="server" src="IMAGENES/AccountLogo2.png" CssClass="imgAccount" OnClick="AccountLogo2_Click"  />                   
                         <asp:ImageButton ID="AccountLogo3" runat="server" src="IMAGENES/AccountLogo3.png" CssClass="imgAccount" OnClick="AccountLogo3_Click"  />
                  </div>
               </div>
          </div>
                      <div class="row">
               <div class="col-sm-12">

                 <div class="CardDefaultP contenedorCentradoHV">
                     <asp:ImageButton ID="AccountLogo5" runat="server" src="IMAGENES/AccountLogo5.png" CssClass="imgAccount" OnClick="AccountLogo5_Click"  />
                     <asp:ImageButton ID="AccountLogo6" runat="server" src="IMAGENES/AccountLogo6.png" CssClass="imgAccount" OnClick="AccountLogo6_Click"  />             
                     <asp:ImageButton ID="AccountIcon4" runat="server" src="IMAGENES/AccountIcon4.png" CssClass="imgAccount" OnClick="AccountIcon4_Click"  />
                    </div>
                  </div>
                  
          </div>
                                 <div class="row">
               <div class="col-sm-12">

                
                  
          </div>
   </div>

             </div>
            </div>

            </div>

        </div>
             <div class="contenedorCentradoHV">
     <asp:Button ID="btnAplyChangesProfile" runat="server" Text="Apply changes" CssClass="textbtn btn-download" OnClick="btnAplyChangesProfile_Click" />
  </div>
    </section>
   
</asp:Content>
