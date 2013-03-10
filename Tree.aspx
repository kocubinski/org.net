<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeFile="Tree.aspx.cs" Inherits="Tree" %>
<%@ Register src="Controls/TaskTree.ascx" tagName="taskTree" tagPrefix="org"%>
<%@ Register src="Controls/CardView.ascx" tagName="cardView" tagPrefix="org" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
        <h2>
            <asp:Label runat="server" ID="lblTitle"/>
        </h2>
    </div>
    <div class="container">
        <div class="row">
            <org:taskTree runat="server" id="taskTree" CssClass="span4" />
            <org:cardView runat="server" ID="contentView" CssClass="span8 hero-unit"/>
        </div>
    </div>
</asp:Content>

