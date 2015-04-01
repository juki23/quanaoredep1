<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="OD.aspx.cs" Inherits="OD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Đặt hàng</h3>
        <p>Nhập thông tin để giao hàng.</p>
    </div>
    <div class="register">
        <div>
            <div class="register-top-grid">
                <h3>Thông tin đặt hàng</h3>
                <div>
                    <span>Ngày Giao hàng</span>
                    <asp:TextBox runat="server" ID="txtDelivery" placeholder="dd/MM/yyyy" />
                </div>
                <div>
                    <span>Ngày mua hàng<label>*</label></span>
                    <asp:TextBox runat="server" ID="txtdateBuy" placeholder="dd/MM/yyyy" Enabled="false" />
                </div>
                <div>
                    <span>Ghi chú</span>
                    <asp:TextBox runat="server" ID="txtnote" placeholder="Ghi chú" />
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="register-but">
            <asp:Button Text="Đặt hàng" ID="btnconfirm" OnClick="btnconfirm_Click" runat="server" BorderWidth="5" BackColor="#f68236" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

