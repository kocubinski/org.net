<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CardView.ascx.cs" 
    Inherits="Controls_CardView" %>

<div id="editDescModal" class="modal hide fade" role="dialog">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
    <h3><%= Model.Title %></h3> 
  </div>
  <div class="modal-body">
    <div class="modal-form">
      <label>Instructions/Toolbar here</label>
      <asp:TextBox TextMode="MultiLine" CssClass="input-xxlarge" rows="10" runat="server" 
        id="txtDescription"></asp:TextBox>
    </div>
  </div>
  <div class="modal-footer">
    <a href="#" class="btn" aria-hidden="true" data-dismiss="modal">Close</a>
    <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="BtnSaveDescriptionClick">
      Save changes
    </asp:LinkButton>
  </div>
</div>
    
<h4><%= Model.Title %></h4>
<asp:Panel runat="server" ID="divContent" CssClass="span8 well well-small">
    <div class="btn-toolbar">
      <div class="btn-group">
        <a href="#" class="btn btn-mini" data-toggle="tooltip" title="Add content">
          <i class="icon-plus"></i>
        </a>
      </div>
    </div>
    <%= Markdown.Transform(Model.Description) %>
    <a href="#editDescModal" data-toggle="modal">Edit description</a>
</asp:Panel>
