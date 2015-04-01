<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .dropdown-header {
            float: left;
            margin-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Sản phẩm</h2>
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
                        <h5>Bảng sản phẩm - Hiển thị tất cả sản phẩm</h5>
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
                                <a href="InsertProduct.aspx" style="float: left;" class="btn btn-primary">Thêm sản phẩm</a>
                                <asp:DropDownList runat="server" ID="ddlarrange" CssClass="dropdown-header" AutoPostBack="true" OnSelectedIndexChanged="ddlarrange_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Sắp xếp" />
                                    <asp:ListItem Value="1" Text="Mã sản phẩm" />
                                    <asp:ListItem Value="2" Text="Tên sản phẩm" />
                                    <asp:ListItem Value="3" Text="Danh mục" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 pull-right" style="margin-right: 32px;">
                                    <asp:TextBox ID="txtsearch" runat="server" Width="87%" CssClass="form-control" placeholder="Tìm kiếm" /><span class="input-group-btn pull-right" style="margin-top: -34px; margin-right: 35px;">
                                        <asp:Button CssClass="btn btn-primary" Text="Tìm" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                                    </span>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="gvproduct" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="5" OnPageIndexChanging="gvproduct_PageIndexChanging"
                            CssClass="table table-striped table-bordered table-hover" OnRowEditing="gvproduct_RowEditing" OnRowDeleting="gvproduct_RowDeleting" OnRowCancelingEdit="gvproduct_RowCancelingEdit">
                            <Columns>
                                <asp:TemplateField HeaderText="Mã SP" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblidpro" Text='<%#Eval("idPro") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã DM" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblidroot" Text='<%#Eval("idCate") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên sản phẩm">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("namePro") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Giá">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("price") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình ảnh">
                                    <ItemTemplate>
                                        <asp:Image ImageUrl='<%# "../Upload/" + Eval("img") %>' runat="server" Width="20" Height="20" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày đăng">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("dateUp","{0:dd/MM/yyyy}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Danh mục">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("nameCate") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trạng thái">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("activePro").ToString().Trim()=="True"?"Hiện":"Ẩn" %>' runat="server" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton CssClass='<%#Eval("activePro").ToString().Trim()=="True"?"fa fa-eye":"fa fa-eye-slash" %>' 
                                            title='<%#Eval("activePro").ToString().Trim()=="True"?"Bấm vào để ẩn sản phẩm":"Bấm vào để hiện sản phẩm" %>' CommandName="Cancel" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;<asp:LinkButton CssClass="fa fa-wrench" CommandName="Edit" title="Sửa" runat="server" />&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;<asp:LinkButton CssClass="fa fa-trash-o" CommandName="Delete" title="Xóa" runat="server" />
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

