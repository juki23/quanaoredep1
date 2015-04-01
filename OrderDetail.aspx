<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Chi tiết đơn hàng của bạn</h3>
        <p>Hiển thị tất cả sản phẩm theo đơn hàng của bạn.</p>
    </div>
    <div style="min-height:500px;">
        <asp:GridView runat="server" ID="gvorderdetail" CssClass="table table-bordered" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Mã">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("idOrderD") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sản phẩm">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("namePro") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Giá">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("price") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số lượng">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Quantity") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

