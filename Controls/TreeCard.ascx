<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeCard.ascx.cs" 
    Inherits="Controls_TreeCard" %>

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