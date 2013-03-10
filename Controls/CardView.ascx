<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CardView.ascx.cs" 
    Inherits="Controls_CardView" %>
    
<asp:Panel runat="server" ID="divContent" CssClass="span6 well">
    <asp:Button runat="server" CssClass="btn btn-primary pull-left" Text="Add"/>
    <asp:Button runat="server" CssClass="btn btn-primary pull-left" Text="Edit"/>
    <asp:Button runat="server" CssClass="btn btn-danger " Text="Delete"/>
    <h4><asp:Label runat="server" ID="lblTitle"></asp:Label></h4>
    <p><asp:Label runat="server" ID="lblText"></asp:Label></p>
</asp:Panel>
