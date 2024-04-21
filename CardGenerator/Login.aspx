<%@ Page Title="" Language="C#" MasterPageFile="~/CardGenerator - FC Mobile.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CardGenerator.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    
    <div class="content-login contenedorCentradoHV">
    <div class="wrapper">
        <form action="">
          <h1>Login</h1>
          <div class="input-box">
              <asp:TextBox ID="txtUsernameLog"  runat="server" placeholder="UserName@oremail.com" required></asp:TextBox>
         <!--   <input type="text" placeholder="Username" required> -->
            <i class='bx bxs-user'></i>
          </div>
          <div class="input-box">
              <asp:TextBox ID="txtPasswordLog" runat="server" placeholder="Password" TextMode="Password" required></asp:TextBox>
        <!--    <input type="password" placeholder="Password" required> -->
            <i class='bx bxs-lock-alt' ></i>
          </div>
              <div class="content-lblo">
              <asp:Label ID="lblMesagge2" runat="server" Text="" CssClass="message-label2"></asp:Label>
              </div>
               <div class="content-lblo">
   <asp:Label ID="lblMesagge" runat="server" Text="" CssClass="message-label"></asp:Label>
   </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
        <!--  <button type="submit" class="btn">Login</button> -->
          <div class="register-link">
            <p>Dont have an account? <a href="Register.aspx">Register</a></p>
          </div>
        </form>
      </div>
    </div>

    <asp:Label ID="lblidUser" runat="server" Text="" Visible="false"></asp:Label>

</asp:Content>
