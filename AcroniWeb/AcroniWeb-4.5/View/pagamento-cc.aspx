<%@ Page Title="" Language="C#" MasterPageFile="~/View/layout.Master" AutoEventWireup="true" CodeBehind="pagamento-cc.aspx.cs" Inherits="AcroniWeb_4._5.pagamento_cc" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="right right-logado right-pagamento-cc" ng-app="cartao">
        <div class="cabecalho cabecalho-cc">
            <div class="cabecalho-info">
                <asp:Label ID="informe" runat="server" class="cartaoTitle" Text="Informe os dados do seu cartão de "></asp:Label>
                <p>
                    Cartões que suportam transições de débito e de crédito poderão ser processados de ambas as formas.<p>
            </div>
            <asp:Image ID="imgCards" runat="server" />
        </div>
        <div class="card-section" ng-controller="ctrl">
            <div class="align align-cc">
                <div class="card">
                    <p ng-bind="numero"></p>
                    <p ng-bind="nome"></p>
                    <p ng-bind="sobrenome"></p>
                    <p ng-bind="data"></p>
                </div>
            </div>
            <div class="card-form">
                <div class="align align-align">
                    <div class="align align-card-form">
                        <div class="textbox-overflow light overflow-type3">
                            <asp:TextBox ID="Nome" runat="server" class="textbox textbox-type3 focus" aria-label="Nome" ng-model="nome" onblur="placehoderStay(0);"></asp:TextBox>
                            <asp:Label ID="lblNome" class="p" runat="server" Text="Nome"></asp:Label>
                        </div>
                        <div class="textbox-overflow light overflow-type3">
                            <asp:TextBox ID="Sobrenome" runat="server" class="textbox textbox-type3 focus" aria-label="Sobrenome" ng-model="sobrenome" onblur="placehoderStay(1);"></asp:TextBox>
                            <asp:Label ID="lblSobrenome" class="p" runat="server" Text="Sobrenome"></asp:Label>
                        </div>
                        <div class="textbox-overflow light overflow-type3">
                            <asp:TextBox ID="Numero" runat="server" class="textbox textbox-type3 focus cartaozinho" aria-label="Número do cartão" ng-model="numero" ng-change="verificarCartao()" onblur="placehoderStay(2);"></asp:TextBox>
                            <asp:Label ID="lblNumero" class="p" runat="server" Text="Número"></asp:Label>
                        </div>
                        <div class="textbox-overflow light overflow-type3">
                            <asp:TextBox ID="DataValidade" runat="server" class="textbox textbox-type3 focus" aria-label="Data de validade" ng-model="data" onblur="placehoderStay(3);"></asp:TextBox>
                            <asp:Label ID="lblDataValidade" class="p" runat="server" Text="Data de validade"></asp:Label>
                        </div>
                        <div class="textbox-overflow light overflow-type3">
                            <asp:TextBox ID="CodigoSeguranca" runat="server" class="textbox textbox-type3 focus" aria-label="Código de segurança" onblur="placehoderStay(4);"></asp:TextBox>
                            <asp:Label ID="lblCodigo" class="p" runat="server" Text="Código de segurança"></asp:Label>
                        </div>
                        <div class="textbox-overflow light overflow-type3 textbox-with-button light">
                            <asp:Button ID="btnSalva" runat="server" Text="Salvo" class="button dark minha-conta" OnClick="btnSalva_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../assets/scripts/vendors/jquery.js"></script>
    <script src="../assets/scripts/vendors/jquery.nicescroll.min.js"></script>
    <script src="../assets/scripts/vendors/jquery.smoothState.js"></script>
    <script src="../assets/scripts/vendors/jquery.mask.min.js"></script>
    <script src="../assets/scripts/vendors/angular.min.js"></script>
    <script src="../assets/scripts/main.js"></script>
    <script src="../assets/scripts/logado.js"></script>
    <script src="../assets/scripts/verificaCartao.js"></script>
    <script src="../assets/scripts/calculoFrete.js"></script>
    <script>
        document.getElementById("pagamento").classList.add("active");
    </script>
    <script>
        $(window).on('load', function () {
            //$("body").niceScroll({ cursorcolor: "#0093ff", cursorwidth: "10px", cursorborder: "none", horizrailenabled:false });
            $("body").niceScroll({ cursorcolor: "#72767d", cursorwidth: "10px", cursorborder: "none", horizrailenabled: false, autohidemode: 'leave', cursoropacitymin: 1, zindex: '99999999' });
            //$(".nicescroll-box").niceScroll({ cursorcolor: "$light-bgray", cursorwidth: "10px", cursorborder: "none", horizrailenabled: false, autohidemode: 'leave', zindex: '99999999' });
            $('.preload').addClass('completo');
            $('nav').addClass('completo');
            $('section').addClass('completo');
            $('.right').addClass('completo');
        });

        function loader(lds, btn) {
            $(lds).css("opacity", "1");
            $(btn).css("color", "#0093ff");
        }
    </script>
</asp:Content>
