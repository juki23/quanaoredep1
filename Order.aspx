<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Đơn hàng</h3>
        <p>Hiển thị tất cả đơn hàng của bạn.</p>
    </div>
    <div class="panel" style="min-height:500px;">
        <asp:GridView runat="server" ID="gvOrderCus" CssClass="table table-bordered" AllowPaging="true" AutoGenerateColumns="false" PageSize="5"
            OnRowEditing="gvOrderCus_RowEditing" OnRowUpdating="gvOrderCus_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Mã">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("idOrder") %>' ID="lblidorder" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày mua">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("dateBuy","{0:dd/MM/yyyy}") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày giao hàng">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("dateDelivery","{0:dd/MM/yyyy}") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("active").ToString().Trim() =="true"? "Đã thanh toán":"Chưa thanh toán" %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton Text="Chi tiết" runat="server" CommandName="Edit" ForeColor="#f68236" />&nbsp;&nbsp;
                        &nbsp;<asp:LinkButton Text="Hủy" runat="server" CommandName="Update" ForeColor="#f68236" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

