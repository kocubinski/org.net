<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="container">
    <h2>
        Top level nodes
    </h2>
    <ul>
        <% foreach (var node in Model) { %>
            <li>
               <a href="tree/<%= node.Id %>"><%= node.Title %></a>
            </li>
        <% } %>
    </ul>
</div>
</asp:Content>
