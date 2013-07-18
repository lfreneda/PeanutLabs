<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PeanutLabs.Web.Webforms._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <title>PeanutLabs integration with ASP.NET Webforms</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        PeanutLabs integration with ASP.NET Webforms</h2>
    <iframe src="<%= IframeUrl %>" width="650px" height="2500px" frameborder="0" scrolling="no">
    </iframe>
</asp:Content>
