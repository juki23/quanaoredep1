<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .img-responsive {
            box-shadow: 1px 1px 1px 1px rgba(142, 135, 135, 0.33);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">
            <asp:Label Text="" ID="lblnameCate" runat="server" /></h3>
        <p>
            <asp:Label Text="" ID="lbldetailCate" runat="server" />
        </p>
        <div class="coat-row" style="min-height: 400px">
            <asp:Repeater runat="server" ID="dtlproduct" OnItemCommand="dtlproduct_ItemCommand">
                <ItemTemplate>
                    <div class="coat-column">
                        <a href='DetailProduct.aspx?id=<%#Eval("idPro") %>'>
                            <asp:Image ImageUrl='<%# "Upload/" + Eval("img") %>' Width="270" Height="300" CssClass="img-responsive" runat="server" />
                            <div class="prod-desc">
                                <h4>
                                    <asp:Label ID="lblnamePro" Text='<%#Eval("namePro") %>' runat="server" />
                                    <asp:Label ID="lblidPro" Text='<%#Eval("idPro") %>' Visible="false" runat="server" /></h4>
                                <small>
                                    <asp:Label ID="lblprice" Text='<%#Eval("price") %>' runat="server" />K
                                </small>
                            </div>
                        </a>
                        <div class="mask">
                            <div class="info" style="float: left;">
                                <a href='DetailProduct.aspx?id=<%#Eval("idPro") %>'>View</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label Text="" ID="lbltest" runat="server" />
            <div class="clearfix"></div>
        </div>
        <cc1:CollectionPager ID="ccpro" runat="server" BackText="« Trước" FirstText=" «« Đầu" LabelText="Trang:"  LastText="Cuối »»" NextText="Sau »"
             ResultsFormat="Từ {0}-{1} (của {2}) Sản phẩm" ShowFirstLast="true" SliderSize="5" PageSize="8">
        </cc1:CollectionPager>
    </div>
</asp:Content>

