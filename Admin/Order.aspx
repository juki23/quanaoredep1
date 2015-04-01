<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Admin_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Hóa đơn</h2>
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
                        <h5>Bảng hóa đơn - Hiển thị tất cả hóa đơn</h5>
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
                                <asp:DropDownList runat="server" ID="ddlarrange" CssClass="dropdown-header" AutoPostBack="true" OnSelectedIndexChanged="ddlarrange_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Sắp xếp" />
                                    <asp:ListItem Value="1" Text="Hóa đơn đã thanh toán" />
                                    <asp:ListItem Value="2" Text="Hóa đơn chưa thanh toán" />
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

                        <asp:GridView ID="gvOrder" runat="server" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" OnPageIndexChanging="gvOrder_PageIndexChanging"
                            AutoGenerateColumns="false" PageSize="2" OnRowEditing="gvOrder_RowEditing" OnRowUpdating="gvOrder_RowUpdating" OnRowDeleting="gvOrder_RowDeleting"
                            OnRowCancelingEdit="gvOrder_RowCancelingEdit">
                            <Columns>
                                <asp:TemplateField HeaderText="Mã HĐ" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("idOrder") %>' ID="lblidOrder" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Khách hàng">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("nameCus") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mã">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("codes") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày mua">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("dateBuy","{0:dd/MM/yyyy}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày giao">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("dateDelivery","{0:dd/MM/yyyy}") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ghi chú">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("notes") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("active").ToString().Trim() == "True" ? "Đã thanh toán" : "Chưa thanh toán" %>' runat="server" />
                                        &nbsp;&nbsp;<asp:LinkButton runat="server" CssClass="fa fa-android" title="Xác nhận thanh toán" CommandName="Cancel" />&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("status1").ToString().Trim() == "True" ? "Đã hủy" : "Còn" %>' runat="server" />
                                        &nbsp;&nbsp;<asp:LinkButton runat="server" CssClass="fa fa-close" title="Hủy" CommandName="Update" />&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:LinkButton runat="server" CssClass="fa fa-list" title="Chi tiết" CommandName="Edit" />&nbsp;
                                        &nbsp;&nbsp;<asp:LinkButton runat="server" CssClass="fa fa-trash-o" title="Xóa" CommandName="Delete" />&nbsp;
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

