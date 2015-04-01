<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="InsertInformation.aspx.cs" Inherits="Admin_InsertInformation" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                        <h5>Thêm thông tin</h5>
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
                                    <label>Tên thông tin *</label>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Tên thông tin" ID="txtnameInfo" />
                                </div>
                                <div class="form-group">
                                    <label>Root</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlrootInfor" >
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Hình ảnh</label>
                                    <asp:FileUpload runat="server" CssClass="form-control" ID="fuimgInfo" />
                                </div>
                                <div class="form-group">
                                    <label>Chi tiết</label>
                                    <CKEditor:CKEditorControl ID="ckedetailInfo" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <asp:Button Text="Cancel" CssClass="btn btn-white" runat="server" ID="btncancelInfo" />
                                    <asp:Button Text="Save changes" CssClass="btn btn-primary" runat="server" ID="btnsaveInfo" OnClick="btnsaveInfo_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

