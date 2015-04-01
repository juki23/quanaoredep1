<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
        
    </div>
    <div class="coats">
        <h3 class="c-head">Liên hệ</h3>
        <p>Hãy gửi cho chúng tôi ý kiến của bạn.</p>
    </div>
    <div class="contact-box">
        <div class="form-t">
            <small>Tên</small>
            <div class="text">
                <input type="text" runat="server" id="iptname" autocomplete="off" placeholder="Tên của bạn" />
            </div>
        </div>
        <div class="form-y">
            <small>Email</small>
            <div class="text">
                <input type="text" runat="server" id="iptemail" autocomplete="off" placeholder="Email của bạn" />
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="form">
            <small>Tin nhắn</small>
            <div class="text">
                <textarea runat="server" id="txamessage" placeholder="Nội dung tin nhắn ..."></textarea>
            </div>
        </div>
        <div class="text">
            <asp:Button ID="btncontext" OnClick="btncontext_Click" Text="Gửi" runat="server" />
        </div>
    </div>
</asp:Content>

