<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="EditCategory.aspx.cs" Inherits="Admin_EditCategory" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                        <h5>Sửa danh mục</h5>
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
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label>Tên danh mục</label>
                                    <asp:TextBox ID="txtnameCate" runat="server" CssClass="form-control" placeholder="Tên danh mục" />
                                </div>
                                <div class="form-group">
                                    <label>Danh mục chứa</label>
                                    <asp:DropDownList ID="ddlidRoot" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Chi tiết danh mục</label>
                                    <CKEditor:CKEditorControl ID="ckedetailCate" BasePath="/ckeditor/" CssClass="form-control" runat="server"></CKEditor:CKEditorControl>
                                </div>
                                
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <asp:Button Text="Cancel" CssClass="btn btn-white" runat="server" />
                                    <asp:Button ID="btneditCate" Text="Save changes" CssClass="btn btn-primary" runat="server" OnClick="btneditCate_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

