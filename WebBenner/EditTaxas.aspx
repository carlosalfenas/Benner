<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTaxas.aspx.cs" Inherits="WebBenner.EditTaxas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function apenasnumerosvirgula(obj, e) {
            var tecla = (window.event) ? e.keyCode : e.which;
            if (tecla == 8 || tecla == 0)
                return true;

            if (tecla != 44 && tecla < 48 || tecla > 57)
                return false;
        }
    </script>

    <div class="widget-header">
        <i class="icon-list-alt"></i>
        <h3>Alterar Dados da Taxa         
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
                                                    <b>DESCRIÇÃO:</b>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDescricao" runat="server" autocomplete="off" Width="313px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>PREÇO:</b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPreco" runat="server" autocomplete="off" Width="313px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>PREÇO ADICIONAL:</b>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrecoAdicional" attrname="telephone1" runat="server" MaxLength="15" autocomplete="off" Width="313px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <b>Ativo:</b>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkAtivo" runat="server" />
                                                </td>
                                            </tr>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <br />               
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="BtnCadastrar" runat="server" class="button btn btn-primary btn-large" Text="Salvar" Width="160px" OnClick="BtnCadastrar_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="BtnVoltar" runat="server" class="button btn btn-primary btn-large" Text="Voltar" Width="160px" PostBackUrl="~/Taxas.aspx" />
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
</asp:Content>
