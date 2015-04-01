<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Admin_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Thông tin</h2>
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
                        <h5>Bảng thông tin - Hiển thị tất cả thông tin</h5>
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
                                <a href="InsertInformation.aspx" class="btn btn-primary ">Thêm thông tin</a>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 pull-right" style="margin-right: 32px;">
                                    <asp:TextBox ID="txtsearch" runat="server" Width="87%" CssClass="form-control" placeholder="Tìm kiếm" /><span class="input-group-btn pull-right" style="margin-top: -34px; margin-right: 35px;">
                                        <asp:Button CssClass="btn btn-primary" Text="Tìm" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </span>
                                </div>
                                <div class="col-lg-2 pull-right">
                                    <asp:RadioButton Text="Tên" GroupName="search" ID="rdbsearchName" CssClass="radio-inline" runat="server" />
                                    <asp:RadioButton Text="Chi tiết" GroupName="search" ID="rdbsearchDetail" CssClass="radio-inline" runat="server" />
                                </div>
                            </div>
                        </div>

                        <asp:GridView runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover"
                            ID="gvInfo" OnRowEditing="gvInfo_RowEditing" OnRowDeleting="gvInfo_RowDeleting" OnPageIndexChanging="gvInfo_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Mã TT">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("idInfo") %>' ID="lblidInfo" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên TT">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("nameInfo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TT chứa">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("rootname") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình ảnh">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("imgInfo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chi tiết" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("detailInfo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        &nbsp;<asp:LinkButton CssClass="fa fa-wrench" title="Sửa" CommandName="Edit" runat="server" />&nbsp;&nbsp;&nbsp;
                                        &nbsp;<asp:LinkButton CssClass="fa fa-trash-o" title="Xóa" CommandName="Delete" runat="server" OnClientClick="return confirm('Are you sure?')" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

