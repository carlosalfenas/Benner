<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntradaSaida.aspx.cs" Inherits="WebBenner.EntradaSaida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="widget-header">
        <i class="icon-list-alt"></i>
        <h3>Entrada e Saída de Veículos</h3>
         <h3 style="text-align:right">
             <asp:Label ID="lblHorario" runat="server" Text="Label"></asp:Label> </h3>
    </div>
    <div class="plan-actions">
        <asp:Button ID="BtnNovaTaxa" runat="server" class="button btn btn-primary btn-large" Text="Marcar Entrada"   Font-Bold="True" OnClick="BtnNovaTaxa_Click" />
   &nbsp;
              
        </div>
    <br />
    <div class="widget-content">

        <div id="Tela" runat="server">

            <asp:UpdatePanel ID="UpdatePanelx" runat="server">
                <ContentTemplate>
                    <div class="text-center">
                        <asp:GridView ID="GVEntradaSaida" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
                            OnPageIndexChanging="GVEntradaSaida_PageIndexChanging" HorizontalAlign ="Center"  OnRowDataBound="GVEntradaSaida_RowDataBound"  AllowPaging="True" DataKeyNames="IdEntradaSaida" BorderColor="#DEDFDE"
                            BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center" PagerStyle-HorizontalAlign ="Center">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                  
                                <asp:BoundField HeaderText="IdEntradaSaida" Visible="False" DataField="IdPreco" />
                                <asp:BoundField HeaderText="Placa" ItemStyle-HorizontalAlign="Center"  Visible="true" DataField="PlacaVeiculo">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Horário de Chegada" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true" DataField="HorarioChegada">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Horário de Saída"   ItemStyle-HorizontalAlign="Center" DataField="HorarioSaida">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Duração"   ItemStyle-HorizontalAlign="Center" DataFormatString="{0:hh:mm:ss}"   DataField="Duracao">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Tempo Cobrado(hora)"   ItemStyle-HorizontalAlign="Center" DataField="TempoCobrado">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                             
                                 <asp:BoundField HeaderText="Preço" ItemStyle-HorizontalAlign="Center" DataField="Preco">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField HeaderText="Valor a Pagar"  ItemStyle-HorizontalAlign="Center" DataField="ValorPagar">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField ItemStyle-Width="10px"  ItemStyle-HorizontalAlign="Center" HeaderText="MARCAR SAÍDA">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server"
                                            ImageUrl="../images/saida.png" OnClick="btnEdit_Click" />                                         
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="10px"  ItemStyle-HorizontalAlign="Center" HeaderText="Excluir">
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
