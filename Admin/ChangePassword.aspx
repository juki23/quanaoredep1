<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChangePassword</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body class="gray-bg">

    <div class="middle-box text-center loginscreen  animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name" style="margin-left: -60px;">QA+</h1>

            </div>
            <h3>Thay đổi mật khẩu</h3>
            <p>
                Điền đầy đủ thông tin phía dưới để thay đổi mật khẩu.
            </p>
            <form class="m-t" role="form" runat="server">
                <div class="form-group">
                    <asp:TextBox ID="txtpassword1" runat="server" placeholder="Mật khẩu hiện tại" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpassword2" runat="server" placeholder="Mật khẩu mới" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpassword3" runat="server" placeholder="Nhập lại mật khẩu" CssClass="form-control" TextMode="Password" />
                </div>
                <asp:Button ID="btnchangepass" Text="Đổi mật khẩu" CssClass="btn btn-primary block full-width m-b" runat="server" OnClick="btnchangepass_Click" />
                <p class="text-muted text-center" style="height: 50px;"><small></small></p>
            </form>
            <p class="m-t"><small>Inspinia we app framework base on Bootstrap 3 &copy; 2014</small> </p>
        </div>
    </div>
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
