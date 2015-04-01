<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="RegisNews.aspx.cs" Inherits="Admin_RegisNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Đăng ký thông tin</h2>
            <ol class="breadcrumb">
            </ol>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Hiển thị tất cả Email</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="col-sm-5 pull-left" style="margin-left: -15px;">
                                <a href="InsertRegisNews.aspx" class="btn btn-primary ">Thêm email</a>
                                <asp:Button ID="btndeleteall" CssClass="btn btn-primary" Text="Xóa" runat="server" OnClick="btndeleteall_Click" />
                                <asp:Button ID="btnsendmail" Text="Gửi mail" CssClass="btn btn-primary" runat="server" OnClick="btnsendmail_Click" />
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 pull-right" style="margin-right: 32px;">
                                    <asp:TextBox ID="txtsearch" runat="server" placeholder="Tìm kiếm" Width="87%" CssClass="form-control" /><span class="input-group-btn pull-right" style="margin-top: -34px; margin-right: 35px;">
                                        <asp:Button CssClass="btn btn-primary" Text="Tìm" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </span>
                                </div>
                            </div>
                            <div>
                                <asp:Label Text="" ID="lbl" Visible="false" ForeColor="Red" runat="server" />
                            </div>
                        </div>
                        <asp:GridView runat="server" ID="gvregisnew" AllowPaging="true" PageSize="3" AutoGenerateColumns="false" OnPageIndexChanging="gvregisnew_PageIndexChanging"
                            CssClass="table table-striped table-bordered table-hover" OnRowEditing="gvregisnew_RowEditing">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="44">
                                    <HeaderTemplate>
                                        &nbsp;&nbsp;<span><asp:CheckBox runat="server" ID="cbselectall" /></span>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<span onclick="getAlldata(<%#Eval("idRegisnew") %>)"><asp:CheckBox runat="server" ID="cbregisnew" /></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblidemail" Text='<%#Eval("idRegisnew") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblemail1" Text='<%#Eval("email") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="150">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;<asp:LinkButton CssClass="fa fa-wrench" CommandName="Edit" title="Sửa" runat="server" />&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;<span class="fa fa-trash-o" style="color: #428bca;" id="del" title="Xóa" onclick="xoa(<%#Eval("idRegisnew") %>)"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <script>
            function xoa(id) {
                var data = { idrg: id };
                var item = event.target;
                var cha = $(item).parent();
                var cha1 = $(cha).parent();
                $.post("Delete.aspx", data, function (event, returnvalue) {
                    if (returnvalue == "success") {
                        $(cha1).remove();
                    }
                });
            }

            function getAlldata(id) {
                var item = event.target;
                if ($(item).is(':checked')) {
                    var data = { idcb: id };
                    $.post("RegisNews.aspx", data);
                } else {
                    var data = { idecb: id };
                    $.post("RegisNews.aspx", data);
                }
            }
        </script>
    </div>
</asp:Content>

