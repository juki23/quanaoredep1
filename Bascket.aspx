<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Bascket.aspx.cs" Inherits="Bascket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats sing-c" runat="server" visible="false">
        <h3 class="c-head">Your Bascket(0)</h3>
        <p>Lorem ipsum dolor sit amet enim. Etiam ullamcorp uspendisse a pellentesque.</p>
        <p>Your Bascket Is Empty Please Go <a href="ShowCatagory.aspx">here</a> And Shop</p>
    </div>
    <div class="coats sing-c" style="height: 800px;">
        <h3 class="c-head">Giỏ hàng của bạn</h3>
        <p>Hiển thị tất cả sản phẩm trong giỏ hàng của bạn.</p>
        <asp:GridView runat="server" AutoGenerateColumns="false" ID="gvCart" CssClass="table table-bordered" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Mã sản phẩm">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("idPro") %>' ID="lblidPro" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên sản phẩm">
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
                        <asp:TextBox ID="txtquantity" Text='<%#Eval("Quantity") %>' BorderWidth="0px" runat="server" Width="50" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Xóa" ForeColor="#f68236" CommandName="lbtdelete" CommandArgument='<%#Container.DataItemIndex %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="float: right;">
            <asp:Label ID="lbltotalcash" runat="server" ForeColor="#303030" />
        </div>
        <br />
        <asp:Label Text="text" ID="lbltest" Visible="false" runat="server" /><br />
        <div style="float: right;">
            <asp:Button Text="Tiếp tục mua hàng" ID="btnnext" OnClick="btnnext_Click" runat="server" BackColor="#f68236" BorderWidth="5" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
            <asp:Button Text="Xóa giỏ hàng" ID="btndeletecart" OnClick="btndeletecart_Click" runat="server" BackColor="#f68236" BorderWidth="5" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
            <asp:Button Text="Cập nhật" ID="btnupdatecart" OnClick="btnupdatecart_Click" runat="server" BackColor="#f68236" BorderWidth="5" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
            <asp:Button Text="Đặt hàng" ID="btnbuypro" OnClick="btnbuypro_Click" runat="server" BackColor="#f68236" BorderWidth="5" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
        </div>
    </div>
</asp:Content>

