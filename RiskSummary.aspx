<%@ Page Title="Summary of Risks" Language="C#" AutoEventWireup="true" CodeBehind="RiskSummary.aspx.cs"
     Inherits="SRA.RiskSummary" MasterPageFile="~/Site.Master" ClientIDMode="Static"%>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
      <div class="content-wrapper">
          <hgroup class="title">
              <h2>Summary of Risks</h2>
          </hgroup>
          <p></p>
      </div>
    </section>     
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Machine Number:</h3>
    <h3>Machine Type:</h3>
    <h3>Date:</h3>

   <div id="gridViewSummaryDiv">
       <asp:GridView ID="gridViewSummary" runat="server" >

       </asp:GridView> 

   </div>

</asp:Content>