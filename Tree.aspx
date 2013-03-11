<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeFile="Tree.aspx.cs" Inherits="Tree" %>
<%@ Register src="Controls/TaskTree.ascx" tagName="taskTree" tagPrefix="org"%>
<%@ Register src="Controls/CardView.ascx" tagName="cardView" tagPrefix="org" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="container">
    <div class="page-header">
      <h1>
        <asp:Label runat="server" ID="lblTitle"/>
      </h1>
      <asp:DataList runat="server" RepeatDirection="Horizontal" ID="listCrumbs">
        <ItemTemplate>
          <span>/</span>
          <asp:LinkButton runat="server" 
            PostBackUrl='<%# string.Format("Tree/{0}/Card/{0}", Eval("Id")) %>'>
            <%# Eval("Title") %>
          </asp:LinkButton>
        </ItemTemplate>
      </asp:DataList>
    </div>
    <div class="row-fluid">
      <org:taskTree runat="server" id="taskTree" />
      <org:cardView runat="server" ID="cardView" />
    </div>
  </div>
</asp:Content>

