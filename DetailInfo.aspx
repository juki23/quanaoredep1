<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="DetailInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
        
    </div>
    <div class="coats">
        <h3 class="c-head">
            <asp:Label Text="About" ID="lblnameInfo" runat="server" /></h3>
    </div>
    <div class="row about-row">
        <div class="col-md-10 about-col">
            <asp:Image ImageUrl="#" Visible="false" ID="imgInfo" runat="server" />
            <div class="who" style="margin:auto; width:120%">
                <p>
                    <asp:Label Text="Detail" ID="lbldetailInfo" runat="server" /></p>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true   // 100% fit in a container
            });
        });
    </script>
</asp:Content>

