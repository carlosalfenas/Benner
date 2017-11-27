<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEntradaSaida.aspx.cs" Inherits="WebBenner.EditEntradaSaida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="widget-header">
        <i class="icon-list-alt"></i>
        <h3>Entrada Saída de Veículos        
        </h3>
    </div>

    <div class="widget-content">
        <fieldset>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <div class="widget-content">
                        <div class="control-group">
                            <div class="tab-pane" id="formcontrols">
                                <fieldset>
                                    <div class="control-group" style="float: left;">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <b>PLACA VEÍCULO:</b>:
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtPlaca" runat="server" placeholder="Digite sua placa ex: XXXX-0000" autocomplete="off" MaxLength="8" Width="313px" ClientIDMode="Static"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>HORÁRIO DE CHEGADA:</b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHorarioChegada" runat="server" placeholder="00:00" autocomplete="off" Width="313px" MaxLength="5" onkeyup="formataHora (this,event);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>HORÁRIO DE SAÍDA:</b>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtHorarioSaida" runat="server" placeholder="00:00" Enabled="false"  autocomplete="off" Width="313px" MaxLength="5" onkeyup="formataHora (this,event);"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="right">
                                                    <b>VALOR:</b>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPreco" Enabled="false" runat="server" MaxLength="15" autocomplete="off" Width="313px"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="right">
                                                    <b>VALOR ADICIONAL:</b>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrecoAdicional" Enabled="false" runat="server" MaxLength="15" autocomplete="off" Width="313px"></asp:TextBox>
                                                </td>
                                            </tr>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="BtnCadastrar" runat="server" class="button btn btn-primary btn-large" Text="Salvar" Width="160px" OnClick="BtnCadastrar_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="BtnVoltar" runat="server" class="button btn btn-primary btn-large" Text="Voltar" Width="160px" PostBackUrl="~/EntradaSaida.aspx" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div style="height: 250px">
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </fieldset>
    </div>

    <script src="Scripts/Mascara.js"></script>
    <script src="Scripts/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#txtPlaca").mask("aaa - 9999");
        });
    </script>

</asp:Content>
