<%@ Page Title="" Language="C#" MasterPageFile="~/CardGenerator - FC Mobile.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CardGenerator.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     
    <div class="content-login contenedorCentradoHV">
        <div class="wrapper">
        <form action="">
            <h1> Register </h1>
            <div class="input-box">
            <!--     <input type="text" placeholder="UserName" required /> -->
                <asp:TextBox runat="server" placeholder="UserName" id="txtUserName"></asp:TextBox>
                <i class="bx bxs-user"></i>
            </div>
            <div class="input-box">
          <!--       <input type="password" placeholder="Password" required /> -->
                 <asp:TextBox runat="server" placeholder="Password" TextMode="Password" id="txtPassword"></asp:TextBox>
                <i class="bx bxs-lock-all"></i>
            </div>
            <div class="content-lblo">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message-label"></asp:Label>
            </div>
        <!--    <button type="submit" class="btn"> Register </button> -->
            <asp:Button runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
            <div class="register-link">
                <p>Dont have an account? <a href="Login.aspx"> Login </a></p>
            </div>
        </form>
    </div>
   </div>
        
</asp:Content>
