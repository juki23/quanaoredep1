<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="Admin_OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Chi tiết hóa đơn</h2>
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
                        <h5>Bảng chi tiết hóa đơn</h5>
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
                        <asp:GridView ID="gvOrdersDetail" runat="server" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="10" OnPageIndexChanging="gvOrdersDetail_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Mã chi tiết hóa đơn">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("idOrderD") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã hóa đơn">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("idOrder") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sản phẩm">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("namePro") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Giá">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("price") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số lượng">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("quantity") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div>
                            Tổng tiền : &euro;<asp:Label Text="text" ID="lbltotal" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

