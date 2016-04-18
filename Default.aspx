<%@ Page Title="Wallis SRA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    Inherits="SRA._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Safety Risk Assessment</h2>
            </hgroup>
            <p>
               
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p><asp:Button ID="btnNewRiskAssessment" runat="server" Text="Create New Risk Assessment" 
       CausesValidation="False" PostBackUrl="~/NewRiskAssessment.aspx" /></p>
    <p><asp:Button ID="btnInProcess" runat="server" Text="View/Modify In Process Risk Assessment" 
       CausesValidation="False" PostBackUrl="~/InProcessRiskAssessments.aspx" />
        <asp:DropDownList ID="ddlInProcess" runat="server"
            AutoPostBack="True" DataSourceID="sraDataSource" CssClass="ddlInProcess"
            DataTextField="machineNumber" DataValueField="machineID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sraDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SRAConnectionString %>"
             SelectCommand="SELECT * FROM [Machine] WHERE active = 1"></asp:SqlDataSource>
</p>
    <p><asp:Button ID="btnViewCompleted" runat="server" Text="View Completed Risk Assessment" 
       CausesValidation="False" PostBackUrl="~/CompletedRiskAssessments.aspx" /></p>
    <p><asp:Button ID="btnStandardsGuidelines" runat="server" Text="Standards & Guidelines" 
       CausesValidation="False" PostBackUrl="~/StandardsGuidelines.aspx" /></p>
</asp:Content>
