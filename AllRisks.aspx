<%@ Page Title="All Risks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllRisks.aspx.cs" 
    Inherits="SRA.AllRisks" ClientIDMode="Static" %>

<asp:Content ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent" runat="server">
     <section class="featured">
      <div class="content-wrapper">
          <hgroup class="title">
              <h2>All Risks</h2>
          </hgroup>
          <p></p>
      </div>
     </section>     
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtText" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
</asp:Content>
