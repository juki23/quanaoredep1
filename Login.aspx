<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Đăng nhập</h3>
        <p>Đăng nhập để mua sản phẩm.</p>
    </div>
    <div class="contact-box login-box">
        <div class="form">
            <small>Email</small>
            <div class="text">
                <asp:TextBox runat="server" placeholder="Email" ID="txtemail" />
            </div>
        </div>
        <div class="form">
            <small>Mật khẩu</small>
            <div class="text">
                <asp:TextBox runat="server" placeholder="Mật khẩu" ID="txtpassword" TextMode="Password" />
            </div>
        </div>
        <div class="text">
            <asp:Button Text="Đăng nhập" runat="server" ID="btnlogin" OnClick="btnlogin_Click" />
        </div>
        <div class="text">
            <a href="ForgotPassword.aspx">Quên mật khẩu</a>
        </div>
    </div>
    <div class="coats login-bot">
        <h3 class="c-head">Cho người mới</h3>
        <p>Bạn hãy đăng ký một tài khoản, hoàn toàn nhanh chóng và miễn phí.</p>
        <div class="reg">
            <a href="Register.aspx">Đăng ký tại đây
            </a>
        </div>
    </div>
</asp:Content>

