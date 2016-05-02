<%@ Page Title="In Process Risk Assessments" Language="C#" AutoEventWireup="true" CodeBehind="InProcessRiskAssessments.aspx.cs" 
    Inherits="SRA.InProcessRiskAssessments" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
      <div class="content-wrapper">
          <hgroup class="title">
              <h2>In Process Safety Risk Assessments</h2>
          </hgroup>
          <p></p>
 </div>
</section>     
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3><asp:Label ID="lblMachineNumberUpdate" runat="server"></asp:Label></h3>
    <h3><asp:Label ID="lblMachineTypeUpdate" runat="server"></asp:Label></h3>
    <h3><asp:Label ID="lblMachineDateUpdate" runat="server"></asp:Label></h3>
</asp:Content>