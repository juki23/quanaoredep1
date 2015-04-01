<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="SendMail.aspx.cs" Inherits="Admin_SendMail" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Hộp thư</h2>
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
                        <h5>Gửi thư</h5>
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
                                    <label>Tới</label>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="name@mail.com" Enabled="false" />
                                </div>
                                <div class="form-group">
                                    <label>Chủ đề</label>
                                    <asp:TextBox runat="server" ID="txtSub" CssClass="form-control" placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Tin nhắn</label>
                                    <CKEditor:CKEditorControl ID="ckeMessage" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <asp:Button Text="Cancel" CssClass="btn btn-white" runat="server" />
                                    <asp:Button Text="Send" ID="btnsendMail" OnClick="btnsendMail_Click" CssClass="btn btn-primary" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

