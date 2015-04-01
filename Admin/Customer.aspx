<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Admin_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Khách hàng</h2>
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
                        <h5>Quản lý khách hàng - hiển thị tất cả</h5>
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
                                <asp:Button ID="btnsort" Text="Sắp xếp" OnClick="btnsort_Click" CssClass="btn btn-primary " runat="server" />
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 pull-right" style="margin-right: 32px;">
                                    <asp:TextBox ID="txtsearch" runat="server" placeholder="Tiềm kiếm tên" Width="87%" CssClass="form-control" /><span class="input-group-btn pull-right" style="margin-top: -34px; margin-right: 35px;">
                                        <asp:Button CssClass="btn btn-primary" Text="Tìm" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="gvCustomer" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="true"
                            PageSize="2" OnRowEditing="gvCustomer_RowEditing" OnPageIndexChanging="gvCustomer_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Mã" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblidCus" Text='<%#Eval("idCus") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("nameCus") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("email") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày sinh">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("birthday","{0:dd/MM/yyyy}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Giới tính">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label CssClass='<%#Eval("sex").ToString().Trim() == "True" ? "fa fa-male":"fa fa-female" %>' runat="server"
                                            title='<%#Eval("sex").ToString().Trim() == "True" ? "Nam":"Nử" %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Địa chỉ">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("address1") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Điện thoại">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("phone") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày đăng ký">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("registerDate","{0:dd/MM/yyyy}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton CssClass="fa fa-list" CommandName="Edit" title="Hóa đơn" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
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

