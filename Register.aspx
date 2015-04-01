<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .dropdown {
            border: 1px solid #f68236;
            outline: none;
            width: 96%;
            font-size: 1em;
            padding: 0.5em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats">
        <h3 class="c-head">Đăng ký</h3>
        <p>Hoàn toàn nhanh chóng và miễn phí.</p>
    </div>
    <div class="register">
        <div style="padding-left: 5%;">
            <div class="register-top-grid">
                <h3>Thông tin cá nhân</h3>
                <div>
                    <span>Họ và Tên
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtcusname" placeholder="Họ và Tên" />
                </div>
                <div>
                    <span>Địa chỉ
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtaddress" placeholder="Địa chỉ" />
                </div>
                <div>
                    <span>Email
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtemail" placeholder="Email" />
                </div>
                <div>
                    <span>Ngày sinh
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtbirthday" CssClass="birth" placeholder="dd/MM/yyyy" />
                </div>
                <div>
                    <span>Điện thoại
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtphone" placeholder="Điện thoại" />
                </div>

                <div>
                    <span>Giới tính
                        <label>*</label></span>
                    <asp:DropDownList runat="server" CssClass="dropdown" ID="ddlsex">
                        <asp:ListItem Value="true" Text="Nam" />
                        <asp:ListItem Value="false" Text="Nữ" />
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
                <a class="news-letter">
                    <label class="checkbox">
                        <asp:CheckBox Checked="true" ID="cbnewletter" runat="server" /><i></i>Đăng ký thông tin</label>
                </a>
                <br />
            </div>
            <div class="register-bottom-grid">
                <h3>Thông tin đăng nhập</h3>
                <div>
                    <span>Mật khẩu
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtpass" TextMode="Password" placeholder="Mật khẩu" />
                </div>
                <div>
                    <span>Xác nhận mật khẩu
                        <label>*</label></span>
                    <asp:TextBox runat="server" ID="txtconfirmpass" TextMode="Password" placeholder="Xác nhận mật khẩu" />
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="text">
            <div>
                <asp:Button Text="Hoàn tất đăng ký" ID="btnregister" OnClick="btnregister_Click" runat="server" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
