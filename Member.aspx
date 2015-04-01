<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="coats" style="min-height:500px;">
        <h3 class="c-head">Thông tin của bạn</h3>
        <p>Hiển thị tất cả đăng ký của bạn</p>
        <div class="panel panel-default">
            <div class="panel-heading">Thông tin người dùng</div>
            <table class="table table-bordered">
                <tr>
                    <td>Họ và tên:</td>
                    <td>
                        <asp:Label Text="text" ID="lblfullname" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:Label Text="text" ID="lblemail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Địa chỉ:</td>
                    <td>
                        <asp:Label Text="text" ID="lbladdress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Số điện thoại:</td>
                    <td>
                        <asp:Label Text="text" ID="lblphone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Giới tính:</td>
                    <td>
                        <asp:Label Text="text" ID="lblsex" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Ngày sinh:</td>
                    <td>
                        <asp:Label Text="text" ID="lblbirth" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Ngày đăng ký:</td>
                    <td>
                        <asp:Label Text="text" ID="lblregisday" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-heading">
            <a href="EditInformation.aspx" style="color: #F68236;">Đổi thông tin</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="ChangePassword.aspx" style="color: #F68236;">Đổi mật khẩu</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="Order.aspx" style="color: #F68236;">Xem đơn hàng</a>
        </div>
    </div>
</asp:Content>

