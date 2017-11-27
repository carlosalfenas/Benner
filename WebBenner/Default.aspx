<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBenner._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CARRO BEM GUARDADO</h1>
        <p class="lead">Controle de Entrada e Saída de Veículos</p>        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>PAGINA INICIAL</h2>
         <p>
                <a class="btn btn-default" href="Default.aspx">Clique Aqui</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>TAXAS</h2>
              <p>
                <a class="btn btn-default" href="Taxas.aspx">Clique Aqui</a>
            </p>        
        </div>
        <div class="col-md-4">
            <h2>ENTRADA SAÍDA</h2>        
            <p>
                <a class="btn btn-default" href="EntradaSaida.aspx">Clique aqui</a>
            </p>
        </div>
    </div>

</asp:Content>
