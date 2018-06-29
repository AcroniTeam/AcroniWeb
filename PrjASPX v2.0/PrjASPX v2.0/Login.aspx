﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrjASPX_v2._0.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/login.css" />
    <script type="text/javascript" src="js/login.js"></script>
</asp:Content>
		

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div id="left">
	         <div id="logo">
			    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 400 400"><path class="st0" d="M122.6 207.1c0 3.3-2.7 6-6 6H42c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6h74.6c3.3 0 6 2.7 6 6V207.1z"/><path class="st0" d="M221.7 207.1c0 3.3-2.7 6-6 6H141c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6h74.6c3.3 0 6 2.7 6 6V207.1z"/><path class="st0" d="M318.6 207.1c0 3.3-2.7 6-6 6H238c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6h74.6c3.3 0 6 2.7 6 6V207.1z"/><path class="st1" d="M170.1 302c0 3.3-2.7 6-6 6H89.4c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6h74.6c3.3 0 6 2.7 6 6V302z"/><path class="st1" d="M267 302c0 3.3-2.7 6-6 6h-74.6c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6H261c3.3 0 6 2.7 6 6V302z"/><path class="st1" d="M364 302c0 3.3-2.7 6-6 6h-74.6c-3.3 0-6-2.7-6-6v-74.6c0-3.3 2.7-6 6-6H358c3.3 0 6 2.7 6 6V302z"/><path class="st2" d="M90.5 183h-4.9c-0.6 0-1-0.2-1.1-0.8l-1-3.5h-9.8l-1 3.5c-0.2 0.6-0.6 0.8-1.1 0.8h-4.9c-0.7 0-1.1-0.4-0.8-1.1l8.4-25.9c0.2-0.6 0.6-0.8 1.2-0.8h6.4c0.6 0 1 0.3 1.2 0.8l8.4 25.9C91.6 182.6 91.2 183 90.5 183zM81.7 172.7l-3.1-10.6 -3.1 10.6H81.7z"/><path class="st2" d="M163.5 169.1c0-8.2 6.1-14.5 14.5-14.5 6.4 0 11.8 4 13.4 9.8 0.2 0.7-0.2 1.1-0.9 1.1h-4.7c-0.6 0-0.9-0.3-1.1-0.8 -1.1-2.4-3.7-3.9-6.7-3.9 -4.9 0-8.1 3.3-8.1 8.3s3.2 8.3 8.1 8.3c3 0 5.6-1.5 6.7-3.9 0.2-0.5 0.6-0.8 1.1-0.8h4.7c0.7 0 1 0.4 0.9 1 -1.6 5.8-7 9.9-13.4 9.9C169.6 183.6 163.5 177.3 163.5 169.1z"/><path class="st2" d="M112 264c0-8.2 6.5-14.5 14.5-14.5 8 0 14.5 6.3 14.5 14.5 0 8.2-6.5 14.5-14.5 14.5C118.5 278.5 112 272.2 112 264zM134.6 264c0-5-3.6-8.3-8.1-8.3 -4.5 0-8.1 3.3-8.1 8.3 0 5 3.6 8.3 8.1 8.3C131 272.3 134.6 269 134.6 264z"/><path class="st2" d="M287.8 183h-5.1c-0.5 0-0.9-0.2-1.2-0.6l-6.8-8.6h-2.5v8.2c0 0.6-0.4 1-1 1h-4.4c-0.6 0-1-0.4-1-1v-25.9c0-0.6 0.4-1 1-1h5.4 4.4c5.3 0 9.6 4.3 9.6 9.6 0 3.3-2 6.4-4.9 8l7.2 9.1C288.9 182.4 288.6 183 287.8 183zM272.2 168.3h4.4c1.8 0 3.2-1.6 3.2-3.6s-1.4-3.6-3.2-3.6h-4.4V168.3z"/><path class="st2" d="M230 250h4.4c0.6 0 1 0.4 1 1v25.9c0 0.6-0.4 1-1 1h-3c-0.5 0-1-0.2-1.2-0.6l-9.5-14.9v14.5c0 0.6-0.4 1-1 1h-4.4c-0.6 0-1-0.4-1-1V251c0-0.6 0.4-1 1-1h3c0.5 0 1 0.2 1.2 0.6l9.5 14.9V251C229 250.4 229.4 250 230 250z"/><path class="st2" d="M318.4 250h4.4c0.6 0 1 0.4 1 1v25.9c0 0.6-0.4 1-1 1h-4.4c-0.6 0-1-0.4-1-1V251C317.4 250.4 317.8 250 318.4 250z"/></svg>
		    </div>
        </div>
        <div id="right">
           <form method="post">
				<div style="padding:0;">
					<p>Login</p>
					<asp:Label runat="server" Text="Entre para acessar sua galeria" id="lblMsg"></asp:Label>
                       <div class="centralizalogin" style="width: 99%;">
					        <asp:Textbox id="txtUsu" class="caixxinha" type="text" placeholder="Usuário" spellcheck="false" autofocus required runat="server"></asp:Textbox>
                            <asp:Textbox id="txtNome" class="confirmar" type="text" placeholder="Nome" spellcheck="false"  runat="server"></asp:Textbox>
                            <asp:Textbox id="txtEmail" class="confirmar" type="text" placeholder="Email" spellcheck="false" runat="server"></asp:Textbox>
                            <asp:Textbox id="txtEndereco" class="confirmar" type="text" placeholder="Endereco" spellcheck="false" runat="server"></asp:Textbox>
                            <asp:Textbox id="txtCidade" class="confirmar" type="text" placeholder="Cidade" spellcheck="false" runat="server"></asp:Textbox>
                            <asp:Textbox id="txtBairro" class="confirmar" type="text" placeholder="Bairro" spellcheck="false" runat="server"></asp:Textbox>
                            <asp:Textbox id="txtCEP" class="confirmar" type="text" placeholder="CEP" spellcheck="false"  runat="server"></asp:Textbox>
                            <asp:Textbox id="txtUF" class="confirmar" type="text" placeholder="UF" spellcheck="false"  runat="server"></asp:Textbox>
                            <asp:Textbox id="txtData" class="confirmar" type="text" placeholder="Data" spellcheck="false"  runat="server"></asp:Textbox>
                            <asp:Textbox id="txtTelefone" class="confirmar" type="text" placeholder="Telefone" spellcheck="false" runat="server"></asp:Textbox>
					        <asp:Textbox id="txtPass" class="caixxinha" type="password" placeholder="Senha" spellcheck="false" required style="margin-bottom:px;" runat="server"></asp:Textbox>
					        <asp:Textbox id="txtCpass" type="password" placeholder="Confirmar senha" spellcheck="false" class="confirmar" style="overflow:hidden" runat="server"></asp:Textbox>
                        </div>
					<asp:Button ID="btnEntra" class="blue" type="button" style="margin-right:10px;" Text="Entrar" runat="server" OnClick="btnEntra_Click" />
					<asp:button ID="btnCad" type="button" class="cadastro" Text="Cadastre-se" runat="server" OnClick="btnCad_Click" />
				</div>
			</form>
        </div>
    </section>
    <script>
        document.getElementById("entrar").classList.add("active");
    </script>
</asp:Content>