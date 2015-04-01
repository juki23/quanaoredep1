<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="ShowCatagory.aspx.cs" Inherits="ShowCatagory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page">
        <!--demo2-->
        <div class="box cf">
            <div class="left">
                <span class="demowrap">
                    <img id="demo2" src="images/2.jpg"></span>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="coats sing-c">
        <h3 class="c-head">
            <asp:Label Text="namePro" Font-Size="1em" ForeColor="#303030" ID="lblnamePro" runat="server" /></h3>
        <p class="article">Mã sản phẩm:
            <asp:Label Text="id" ID="lblidPro" runat="server" /></p>
        <p>Gía : &euro;
            <asp:Label Text="price" ID="lblprice" runat="server" /></p>
        <p>
            Số lượng : <asp:TextBox runat="server" ID="txtquantity" Text="1" Width="50" />
            <asp:Button Text="Giỏ hàng" ID="btncart" BorderStyle="Solid" runat="server" ForeColor="White" BackColor="#f68236" BorderColor="#f68236" />
            <asp:Button Text="Mua hàng" ID="btnbuy" BorderStyle="Solid" runat="server" ForeColor="White" BackColor="#f68236" BorderColor="#f68236" />
        </p>
        <p class="art">
            <asp:Label Text="Detail" ID="lbldetailpro" runat="server" />
        </p>
    </div>
</asp:Content>

