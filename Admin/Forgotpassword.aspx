<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgotpassword.aspx.cs" Inherits="Admin_Forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
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
            <p>&nbsp;</p>
            <h3>Quên mật khẩu</h3>
            <p>
                Chúng tôi sẽ gửi mật khẩu vào email của bạn. Bạn có thể kiếm tra email sau khi bấm nút <br />
                "Send Mail"
               
                <!--Continually expanded and constantly improved Inspinia Admin Them (IN+)-->
            </p>
            <p>&nbsp;</p>
            <form class="m-t" role="form" runat="server">
                <asp:Button ID="btnsendmail" Text="Send Mail" CssClass="btn btn-primary block full-width m-b" runat="server" OnClick="btnsendmail_Click" />
                <p class="text-muted text-center" style="height: 150px;"><small></small></p>
            </form>
            <p class="m-t"><small>Inspinia we app framework base on Bootstrap 3 &copy; 2014</small> </p>
        </div>
    </div>
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
