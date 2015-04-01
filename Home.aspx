<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .sp {
            background: white;
            height: 70px;
            width: 100%;
            box-shadow: 0px 0px 1px silver;
        }

            .sp span {
                font-family: 'Josefin Sans', sans-serif;
                font-weight: 400;
                border-bottom: 0px;
                padding: 20px 12px 27px;
                float: left;
                font-size: 20px;
                text-align: left;
            }

        .img-responsive {
            box-shadow: 1px 1px 1px 1px rgba(142, 135, 135, 0.33);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" />
    <div class="banner">
        <h1>Hazy Shade of spring</h1>
        <small>Quisque lorem tortor fringilla sed, vestibulum id, eleifend justo.</small>
        <div class="ban-btn">
            <a href="#">check new arrivals</a>
        </div>
    </div>
    <div class="gallery">
        <div style="margin-top: 45px;">
            <div class="sp">
                <span>Sản phẩm nổi bật</span>
            </div>
            <hr />
        </div>
        <asp:Repeater runat="server" ID="repproduct">
            <ItemTemplate>
                <div class="coat-column">
                    <a href='DetailProduct.aspx?id=<%#Eval("idPro") %>'>
                        <asp:Image ImageUrl='<%# "Upload/" + Eval("img") %>' Width="270" Height="300" BorderStyle="Solid" CssClass="img-responsive" runat="server" />
                        <div class="prod-desc">
                            <h4>
                                <asp:Label ID="lblnamePro" Text='<%#Eval("namePro") %>' runat="server" />
                                <asp:Label ID="lblidPro" Text='<%#Eval("idPro") %>' Visible="false" runat="server" /></h4>
                            <small>
                                <asp:Label ID="lblprice" Text='<%#Eval("price") %>' runat="server" />
                                K
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
    </div>
    <div style="float: right;">
        <a href="ShowProducts.aspx" style="color: #F68236;">Xem tất cả</a>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="subscribe">
                <h3>Đăng ký nhận thông tin</h3>
                <p>Bạn sẽ nhận được những thông tin mới nhất</p>
                <div class="text">
                    <input type="text" placeholder="Email của bạn" id="iptemail" runat="server" style="width: 40%; height: 47.5px" />
                    <asp:Button Text="Thêm" ID="btnaddEmail" OnClick="btnaddEmail_Click" runat="server" />
                </div>
                <div class="text">
                    <asp:Label ID="lblerror" ForeColor="Red" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
