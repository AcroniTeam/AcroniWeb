﻿<%@ Page Title="" Language="C#" MasterPageFile="~/logado.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="AcroniWeb_4._5.galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
            <asp:Image ID="imgColecao" class="colecao-picture" runat="server" ImageUrl='' />
            <asp:Image ID="imgStatus" class="galeria-status" runat="server"  ImageUrl='img/galeria-vazia.png' />


      <script>
        document.getElementById("galeria").classList.add("active");
    </script>
</asp:Content>
