<%@ Page Title="New Risk" Language="C#" AutoEventWireup="true" CodeBehind="AddRisk.aspx.cs" 
    Inherits="SRA.AddRisk" MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
      <div class="content-wrapper1">
          <hgroup class="title">
              <h2>New Risk Assessment - Machine Risk Details</h2>
          </hgroup>
          <p></p>
 </div>
</section>     
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <h3><asp:Label ID="lblMachineNumber" runat="server"></asp:Label></h3>
    <h3><asp:Label ID="lblMachineType" runat="server"></asp:Label></h3>

    <p>&nbsp;<asp:ValidationSummary ID="DecriptionSummary" runat="server" ValidationGroup="Description" DisplayMode="List" ForeColor="Red"/>
    
        <p>
    <table id="riskTable">
        <tr>
            <th>Hazard Description:</th>
            <td>Severity</td>
            <td>Likelihood</td>
            <td>Frequency</td>
            <td>Number Persons</td>
            <td>Risk</td>
            <td>Risk Description</td>
        </tr>
         <tr>
            <td><asp:TextBox ID="txtHazardDescription" runat="server" TextMode="MultiLine" Rows="2">
                            </asp:TextBox></td>
             <asp:RequiredFieldValidator ID="RequiredFieldHazardDesc" runat="server" ControlToValidate="txtHazardDescription" ErrorMessage="*Hazard Description Required" Display="None" ForeColor="Red" ValidationGroup="Description"></asp:RequiredFieldValidator>
            <td>
                 <asp:DropDownList CssClass="riskDropDowns" ID="ddlHazardSeverity" runat="server" AutoPostBack="True" 
                     OnSelectedIndexChanged="UpdateHazardRiskSeverity" DataSourceID="dsLoadSeverityValues" DataTextField="severityValue" DataValueField="severityValue"></asp:DropDownList>
                 <asp:SqlDataSource ID="dsLoadSeverityValues" runat="server" ConnectionString="<%$ ConnectionStrings:SRAConnectionString %>" SelectCommand="spLoadSeverityValues" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
             </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlHazardLikelyhood" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="UpdateHazardRiskLikelyhood" DataSourceID="dsLoadLikelihoodValues" DataTextField="likelihoodValue" DataValueField="likelihoodValue"></asp:DropDownList>
                <asp:SqlDataSource ID="dsLoadLikelihoodValues" runat="server" ConnectionString="<%$ ConnectionStrings:SRAConnectionString %>" SelectCommand="spLoadLikelihoodValues" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlHazardFrequency" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="UpdateHazardRiskFrequency"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlHazardNumberOfPersons" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="UpdateHazardRiskNumberOfPersons"></asp:DropDownList>
            </td>
            <td><asp:Label ID="lblHazardRisk" runat="server"></asp:Label></td>
             <td><asp:Label ID="lblHazardRiskMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th>Hazard Reduction Solution:</th>
        </tr>
         <tr>
            <td><asp:TextBox ID="txtReductionSolutionDescription" runat="server" TextMode="MultiLine" Rows="2">
                            </asp:TextBox></td>

             <asp:RequiredFieldValidator ID="RequiredFieldReductionDesc" runat="server" ControlToValidate="txtReductionSolutionDescription" ErrorMessage="*Reduction Solution Description Required" Display="None" ForeColor="Red" ValidationGroup="Description"></asp:RequiredFieldValidator> 
            <td>
                 <asp:DropDownList CssClass="riskDropDowns" ID="ddlReductionSolutionSeverity" runat="server" AutoPostBack="True"
                     OnSelectedIndexChanged="UpdateReductionSolutionRiskSeverity" DataSourceID="dsLoadSeverityValues" DataTextField="severityValue" DataValueField="severityValue"></asp:DropDownList>
             </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlReductionSolutionLikelyhood" runat="server" AutoPostBack="True"
                     OnSelectedIndexChanged="UpdateReductionSolutionRiskLikelyhood" DataSourceID="dsLoadLikelihoodValues" DataTextField="likelihoodValue" DataValueField="likelihoodValue"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlReductionSolutionFrequency" runat="server" AutoPostBack="true"
                     OnSelectedIndexChanged="UpdateReductionSolutionRiskFrequency"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlReductionSolutionNumberOfPersons" runat="server" AutoPostBack="true"
                     OnSelectedIndexChanged="UpdateReductionSolutionRiskNumberOfPersons"></asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblReductionSolutionRisk1" runat="server"></asp:Label></td>
             <td><asp:Label ID="lblReductionSolutionRiskMessage" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <th>Administrative Solutions:</th>
        </tr>
         <tr>
            <td><asp:TextBox ID="txtAdminSolutionDescription" runat="server" TextMode="MultiLine" Rows="2">
                            </asp:TextBox></td>

             <asp:RequiredFieldValidator ID="RequiredFieldAdminDesc" runat="server" ControlToValidate="txtAdminSolutionDescription"
                 ErrorMessage="*Administrative Solution Description Required" Display="None" ForeColor="Red" ValidationGroup="Description"></asp:RequiredFieldValidator> 
           <td>
                 <asp:DropDownList CssClass="riskDropDowns" ID="ddlAdminSolutionSeverity" runat="server" AutoPostBack="True"
                     OnSelectedIndexChanged="UpdateAdminSolutionRiskSeverity" DataSourceID="dsLoadSeverityValues" DataTextField="severityValue" DataValueField="severityValue"></asp:DropDownList>
             </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlAdminSolutionLikelyhood" runat="server" AutoPostBack="True"
                     OnSelectedIndexChanged="UpdateAdminSolutionRiskLikelyhood" DataSourceID="dsLoadLikelihoodValues" DataTextField="likelihoodValue" DataValueField="likelihoodValue"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlAdminSolutionFrequency" runat="server" AutoPostBack="true"
                     OnSelectedIndexChanged="UpdateAdminSolutionRiskFrequency"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList CssClass="riskDropDowns" ID="ddlAdminSolutionNumberOfPersons" runat="server" AutoPostBack="true"
                     OnSelectedIndexChanged="UpdateAdminSolutionRiskNumberOfPersons"></asp:DropDownList>
            </td>
            <td><asp:Label ID="lblAdminSolutionRisk" runat="server"></asp:Label></td>
             <td><asp:Label ID="lblAdminSolutionRiskMessage" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td colspan="7"><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="3" placeholder="Comments...">
                            </asp:TextBox></td>     
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td colspan="2" style="float: right"><asp:Button ID="btnNewRisk" runat="server" Text="Add Risk"  
       CausesValidation="true" PostBackUrl="~/AddRisk.aspx" ValidationGroup="Description" OnClick="btnNewRisk_Click"/></td>
            <td colspan="2"><asp:Button ID="btnDoneNewRisk" runat="server" Text="Done" OnClick="btnDoneNewRisk_Click" CausesValidation="false"/></td>
        </tr>
    </table>
    <p><asp:Label ID="testMessage" runat="server"></asp:Label></p>
</asp:Content>