<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeCard.ascx.cs" 
    Inherits="Controls_TreeCard" %>


<asp:Panel runat="server" CssClass="card-child well well-small" ID="pnlCard">
    <asp:LinkButton runat="server" ID="btnTitle" CssClass="tree-card-title"/>
    <div class="btn-group" style="margin-left: 5px;">
        <a href="#createCardModal" class="btn btn-mini" data-toggle="modal" title="Add card here">
          <i class="icon-plus"></i>
        </a>
        <asp:LinkButton runat="server" CssClass="btn btn-mini" ID="btnDeleteCard">
          <i class="icon-trash"></i>
        </asp:LinkButton>
    </div>
</asp:Panel>