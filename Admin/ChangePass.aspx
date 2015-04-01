<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Admin_ChangePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Quản lý</h2>
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
                        <h5>Đổi mật khẩu</h5>
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
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-lg-2 control-label" style="margin-top:5px;">Mật khẩu hiện tại</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox runat="server" ID="txtpassword1" placeholder="Mật khẩu hiện tại" TextMode="Password" CssClass="form-control" />
                                        <span class="help-block m-b-none">&nbsp;</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label" style="margin-top:5px;">Mật khẩu mới</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox runat="server" ID="txtpassword2" placeholder="Mật khẩu mới" TextMode="Password" CssClass="form-control" />
                                        <span class="help-block m-b-none">&nbsp;</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label" style="margin-top:5px;">Xác nhận</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox runat="server" ID="txtpassword3" placeholder="Xác nhận" TextMode="Password" CssClass="form-control" />
                                        <span class="help-block m-b-none">&nbsp;</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-offset-2 col-lg-10">
                                        <asp:Button Text="Đổi mật khẩu" ID="btnchangepass" CssClass="btn btn-sm btn-white" OnClick="btnchangepass_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

