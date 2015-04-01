<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Quên mật khẩu</h3>
        <p>Chúng tôi sẽ gửi mật khẩu qua email cho bạn.</p>
    </div>
    <div class="register" style="margin-left: 30%;">
        <div class="register-top-grid">
            <h3></h3>
            <div>
                <span></span>
                <asp:TextBox runat="server" placeholder="Email" ID="txtforgotpass" />
            </div>
        </div>
        <div class="register-but" style="margin-top: 14px;">
            <asp:Button Text="Send" ID="btnSendPass" runat="server" OnClick="btnSendPass_Click" BackColor="#f68236" BorderColor="#f68236" BorderWidth="7" ForeColor="White" BorderStyle="Solid" />
        </div>
        <div class="clearfix"></div>
    </div>
</asp:Content>

