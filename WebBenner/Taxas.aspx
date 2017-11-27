<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Taxas.aspx.cs" Inherits="WebBenner.Taxas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="widget-header">
        <i class="icon-list-alt"></i>
        <h3>TAXAS </h3>
    </div>
    <div class="plan-actions">
        <asp:Button ID="BtnNovaTaxa" runat="server" class="button btn btn-primary btn-large" Text="Novo Cadastro de Taxas" PostBackUrl="~/EditTaxas.aspx?ID=0" />
    </div>
    <br />
    <div class="widget-content">

        <div id="Tela" runat="server">

            <asp:UpdatePanel ID="UpdatePanelx" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="GVTaxas" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
                            OnPageIndexChanging="GVTaxas_PageIndexChanging" OnRowDataBound="GVTaxas_RowDataBound"  AllowPaging="True" DataKeyNames="IdPreco" BorderColor="#DEDFDE"
                            BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" HeaderStyle-HorizontalAlign="Justify">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Usando"  ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Flag" Enabled ="false" DataField="Flag" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="IdPreco" Visible="False" DataField="IdPreco" />
                                <asp:BoundField HeaderText="Descricao" ItemStyle-HorizontalAlign="Center" Visible="true" DataField="Descricao">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Valor da Hora" ItemStyle-HorizontalAlign="Center" Visible="true" DataField="Preco">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Preço Adicional" ItemStyle-HorizontalAlign="Center" DataField="PrecoAdicional">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data Cadastro" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" DataField="DataCadastro">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Data Alteracao" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" DataField="DataAlteracao">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                             

                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center" HeaderText="Alterar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server"
                                            ImageUrl="../images/editar.gif" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center" HeaderText="Excluir">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnExcluir" runat="server"
                                            ImageUrl="../images/excluir.gif"
                                            OnClientClick="javascript:return confirm('Tem certeza que deseja este registro?');"
                                            OnClick="btnExcluir_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>

                            </Columns>

                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
