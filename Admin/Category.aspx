<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Danh mục</h2>
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
                        <h5>Bảng danh mục - hiển thị tất cả danh mục</h5>
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
                                <a href="InsertCategory.aspx" class="btn btn-primary ">Thêm danh mục</a>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 pull-right" style="margin-right: 32px;">
                                    <asp:TextBox ID="txtsearch" runat="server" placeholder="Tìm kiếm" Width="87%" CssClass="form-control" /><span class="input-group-btn pull-right" style="margin-top: -34px; margin-right: 35px;">
                                        <asp:Button CssClass="btn btn-primary" Text="Tìm" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="gvCategory" runat="server" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered table-hover"
                            OnRowEditing="gvCategory_RowEditing" OnRowDeleting="gvCategory_RowDeleting" OnRowUpdating="gvCategory_RowUpdating"
                            OnPageIndexChanging="gvCategory_PageIndexChanging" OnRowCancelingEdit="gvCategory_RowCancelingEdit" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("idCate") %>' ID="lblidCate" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên danh mục">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("nameCate") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Danh mục chứa">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("rootname")%>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chi tiết danh mục" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("detailCate") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trạng thái">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("activeCate").ToString().Trim()=="True"?"Hiện":"Ẩn" %>' runat="server" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton CssClass='<%#Eval("activeCate").ToString().Trim()=="True"?"fa fa-eye":"fa fa-eye-slash" %>' CommandName="Cancel"
                                             title='<%#Eval("activeCate").ToString().Trim()=="True"?"Bấm để ẩn danh mục":"Bấm để hiện danh mục" %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        &nbsp;<asp:LinkButton CssClass="fa fa-list" CommandName="Edit" runat="server" title="Chi tiết" />&nbsp;&nbsp;&nbsp;
                                        &nbsp;<asp:LinkButton CssClass="fa fa-wrench" CommandName="Update" runat="server" title="Sửa" />&nbsp;&nbsp;&nbsp;
                                        &nbsp;<asp:LinkButton CssClass="fa fa-trash-o" CommandName="Delete" runat="server" OnClientClick="return confirm('Bạn chắc chắn muốn xóa ?')" title="Xóa" />
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

