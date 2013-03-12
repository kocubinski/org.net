<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeFile="Tree.aspx.cs" Inherits="Tree" %>
<%@ Register src="Controls/TaskTree.ascx" tagName="taskTree" tagPrefix="org"%>
<%@ Register src="Controls/CardView.ascx" tagName="cardView" tagPrefix="org" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

  <div id="createCardModal" class="modal hide fade" role="dialog">
    <div class="modal-header">
      <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
      <h3>Create new card</h3> 
    </div>
    <div class="modal-body">
      <div class="modal-form">
        <label>Title</label>
        <asp:TextBox runat="server" ID="txtNewCardTitle"/>
        <label>Description</label>
        <asp:TextBox TextMode="MultiLine" CssClass="input-xxlarge" rows="10" runat="server" 
              id="txtNewCardDescription" />
      </div>
    </div>
    <div class="modal-footer">
      <a href="#" class="btn" aria-hidden="true" data-dismiss="modal">Close</a>
      <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnCreateCard">
          Create
      </asp:LinkButton>
    </div>
  </div> 

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

