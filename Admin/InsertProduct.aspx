<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="InsertProduct.aspx.cs" Inherits="Admin_InsertProduct" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                        <h5>Thêm sản phẩm</h5>
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
                                    <label>Tên sản phẩm *</label>
                                    <asp:TextBox ID="txtnamepro" runat="server" CssClass="form-control" placeholder="Tên sản phẩm" />
                                </div>
                                <div class="form-group">
                                    <label>Giá *</label>
                                    <asp:TextBox ID="txtprice" runat="server" CssClass="form-control" placeholder="Giá" />
                                </div>
                                <div class="form-group">
                                    <label>Hình ảnh</label>
                                    <asp:FileUpload ID="fuimgpro" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>Danh mục *</label>
                                    <asp:DropDownList runat="server" ID="ddlcategory" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Value="-1" Text="Chọn danh mục" ></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Chi tiết sản phẩm</label>
                                    <CKEditor:CKEditorControl ID="ckeproduct" BasePath="~/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                </div>
                                <div class="form-group">

                                    <div class="col-sm-10">
                                        <div class="checkbox i-checks">
                                            <label>
                                                <asp:CheckBox ID="cbactive" Text="Active" runat="server" />
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-4">
                                    <asp:Button Text="Cancel" CssClass="btn btn-white" runat="server" />
                                    <asp:Button Text="Save changes" ID="btnsavePro" CssClass="btn btn-primary" runat="server" OnClick="btnsavePro_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Peity -->
    <script src="js/demo/peity-demo.js"></script>
    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green',
            });
        });
    </script>
</asp:Content>

