<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="EditInformation.aspx.cs" Inherits="EditInformation" %>

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
        <h3 class="c-head">Thay đổi thông tin</h3>
        <%--<p>&nbsp;</p>--%>
    </div>
    <div class="register">
        <div>
            <div class="register-top-grid">
                <h3>Thông tin cá nhân</h3>
                <div>
                    <span>Họ và Tên<label>*</label></span>
                    <asp:TextBox runat="server" ID="txtcusname" placeholder="Họ và Tên" />
                </div>
                <div>
                    <span>Địa chỉ<label>*</label></span>
                    <asp:TextBox runat="server" ID="txtaddress" placeholder="Địa chỉ" />
                </div>
                <div>
                    <span>Ngày sinh<label>*</label></span>
                    <asp:TextBox runat="server" ID="txtbirthday" CssClass="birth" placeholder="dd/MM/yyyy" />
                </div>
                <div>
                    <span>Điện thoại<label>*</label></span>
                    <asp:TextBox runat="server" ID="txtphone" placeholder="Điện thoại" />
                </div>

                <div>
                    <span>Giới tính<label>*</label></span>
                    <asp:DropDownList runat="server" CssClass="dropdown" ID="ddlsex">
                        <asp:ListItem Value="true" Text="Nam" />
                        <asp:ListItem Value="false" Text="Nữ" />
                    </asp:DropDownList>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="register-but">
            <asp:Button Text="Cập nhật" ID="btnupdateCus" OnClick="btnupdateCus_Click" runat="server" BackColor="#f68236" BorderStyle="Solid" BorderColor="#f68236" ForeColor="White" />
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

