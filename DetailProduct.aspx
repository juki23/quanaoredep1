<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MasterTL.master" AutoEventWireup="true" CodeFile="DetailProduct.aspx.cs" Inherits="DetailProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/demo1.css" rel="stylesheet" />
    <link href="css/imagezoom.css" rel="stylesheet" />
    <link href="css/es-cus.css" rel="stylesheet" />
    <%--<script type="text/javascript" src="js/jquery.imagezoom.min.js"></script>--%>
    <script type="text/javascript" src="js/modernizr.custom.17475.js"></script>
    <script type="text/javascript" src="js/jquery.elastislide.js"></script>
    <script type="text/javascript">
        eval(function (p, a, c, k, e, d) { e = function (c) { return (c < a ? "" : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) d[e(c)] = k[c] || e(c); k = [function (e) { return d[e] }]; e = function () { return '\\w+' }; c = 1; }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p; }('$(7(){$(\'#1d\').j();9 a=$(\'#12\').A({B:0,z:3,C:7(c,d,e){c.E().D("8");c.k("8");a.y(d);e.x();9 f=$(\'#16\').g(\'m\');f.K(c.l(\'i\').M(\'G\'),c.l(\'i\').g(\'L\'))},H:7(){$(\'#16\').j({t:\'u/v/3.p\'});$(\'#12 J:F(0)\').k(\'8\')}});$(\'#W\').j({w:\'X\',17:[o,s],t:\'u/v/6.p\',15:[10,-4],r:\'13\'});9 b=$(\'#W\').g(\'m\');$(n).N(7(){h=$(n).U();S(h>R){b.q(o,s)}T{b.q(h*0.4,h*0.4*0.14)}});9 a=$(\'#O\').A({B:1,z:4,C:7(c,d,e){c.E().D("8");c.k("8");a.y(d);e.x();9 f=$(\'#I\').g(\'m\');f.K(c.l(\'i\').M(\'G\'),c.l(\'i\').g(\'L\'))},H:7(){$(\'#I\').j({w:\'X\',17:[o,s],t:\'u/v/2.p\',15:[10,-4],r:\'13\',1a:7(c){c.$Q.1b().19(P)},18:7(c){c.$Q.1f().1e(P)}});$(\'#O J:F(1)\').k(\'8\');$(n).N(7(){9 c=$(\'#I\').g(\'m\');h=$(n).U();S(h>R){c.q(o,s)}T{c.q(h*0.4,h*0.4*0.14)}})}});$(\'#1c\').j({w:\'Y\',r:\'11\'});9 a=$(\'#Z\').A({B:0,z:4,C:7(c,d,e){c.E().D("8");c.k("8");a.y(d);e.x();9 f=$(\'#V\').g(\'m\');f.K(c.l(\'i\').M(\'G\'),c.l(\'i\').g(\'L\'))},H:7(){$(\'#V\').j({w:\'Y\',t:\'u/v/5.p\',r:\'11\'});$(\'#Z J:F(0)\').k(\'8\')}})});', 62, 78, '|||||||function|active|var|||||||data|winWidth|img|ImageZoom|addClass|find|imagezoom|window|480|jpg|changeZoomSize|zoomViewerClass|300|bigImageSrc|demo_assets|large|type|preventDefault|setCurrent|minItems|elastislide|start|onClick|removeClass|siblings|eq|src|onReady|demo4|li|changeImage|largeimg|attr|resize|demo4carousel|500|viewer|900|if|else|width|demo6|demo3|standard|follow|demo2carousel||followViewer|demo2carousel|standardViewer|625|offset|demo2|zoomSize|onHide|fadeIn|onShow|hide|demo5|demo1|fadeOut|show'.split('|'), 0, {}))
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pag-nav">
    </div>
    <div class="page">
        <div class="box cf">
            <div class="left">
                <span class="demowrap">
                    <asp:Image ImageUrl="images/3.jpg" ID="imgPro" Width="500" runat="server" /></span>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="coats sing-c">
        <h3 class="c-head">
            <asp:Label Text="namePro" Font-Size="1em" ForeColor="#303030" ID="lblnamePro" runat="server" /></h3>
        <p class="article">
            Mã sản phẩm:
            <asp:Label Text="id" ID="lblidPro" runat="server" />
        </p>
        <p>
            Gía : 
            <asp:Label Text="price" ID="lblprice" runat="server" />K
        </p>
        <p>
            Số lượng :
            <asp:TextBox runat="server" ID="txtquantity" Text="1" Width="50" />
            <asp:Button Text="Giỏ hàng" ID="btncart" OnClick="btncart_Click" BorderStyle="Solid" runat="server" ForeColor="White" BackColor="#f68236" BorderColor="#f68236" />
            <asp:Button Text="Mua hàng" ID="btnbuy" OnClick="btnbuy_Click" BorderStyle="Solid" runat="server" ForeColor="White" BackColor="#f68236" BorderColor="#f68236" />
        </p>
        <p class="art">
            <asp:Label Text="Detail" ID="lbldetailpro" runat="server" />
        </p>
    </div>
</asp:Content>

