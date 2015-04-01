<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Đổi mật khẩu</h3>
    </div>
    <div class="register">
        <div class="register-bottom-grid">
            <div>
                <span>Mật khẩu hiện tại <label>*</label></span>
                <asp:TextBox runat="server" ID="txtpass1" TextMode="Password" />
            </div>
            <div>
                <span>Mật khẩu mới <label>*</label></span>
                <asp:TextBox runat="server" ID="txtpass2" TextMode="Password" />
            </div>
            <div>
                <span>Xác nhận mật khẩu mới <label>*</label></span>
                <asp:TextBox runat="server" ID="txtpass3" TextMode="Password" />
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="text" >
            <div>
                <asp:Button Text="Đổi mật khẩu" ID="btnchangePass" OnClick="btnchangePass_Click" runat="server" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>

