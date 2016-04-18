<%@ Page Title="New Risk" Language="C#" AutoEventWireup="true" CodeBehind="NewRiskAssessment.aspx.cs" 
    Inherits="SRA.NewRisk" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
      <div class="content-wrapper">
          <hgroup class="title">
              <h2>New Risk Assessment</h2>
          </hgroup>
          <p></p>
 </div>
</section>     
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h3>New Risk Assessment</h3>--%>
    <%--<asp:ValidationSummary ID="validationSummary" runat="server" 
        HeaderText="Please correct errors" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" /> --%>
  
    <table>
        <tr>
            <td><label>Date:</label></td>
            <td>
                <asp:Label runat="server" ID="lblDate"></asp:Label>
                <%--<asp:TextBox ID="txtDate" runat="server" Width="200px"></asp:TextBox>--%>
                     <%--<asp:RegularExpressionValidator ID="validateDateFormat" runat="server" ControlToValidate="txtDate"
                     ValidationExpression="(((0|1)[1-9]|2[1-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                     ErrorMessage="Invalid date format." />     --%>
            </td>
        </tr>
        <tr>
            <td><label>Machine Number:</label></td>
            <td><asp:TextBox ID="txtMachineNumber" runat="server" Width="200px"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorMachineNumber" runat="server" 
                ControlToValidate="txtMachineNumber" ErrorMessage="*Machine Number Required" Display="Static"
                ForeColor="Red" ValidationGroup="AddParticipant"></asp:RequiredFieldValidator></td>
        </tr>
       <tr>
            <td><label>Machine Type:</label></td>
            <td><asp:TextBox ID="txtMachineType" runat="server" Width="200px"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorMachineType" runat="server"
                ControlToValidate="txtMachineType" ErrorMessage="*Machine Type Required" Display="Static"
               ForeColor="Red" ValidationGroup="AddParticipant"></asp:RequiredFieldValidator></td> 
        </tr>
      <tr>
            <td><asp:TextBox ID="txtParticipantFirstName" placeholder="Participant First Name" runat="server" Width="200px"></asp:TextBox></td>
            <td><asp:TextBox ID="txtParticipantLastName" placeholder="Participant Last Name" runat="server" Width="200px"></asp:TextBox></td>
            <td><asp:TextBox ID="txtParticipantTitle" runat="server" placeholder="Title/Role" Width="200px"></asp:TextBox></td>  
            <td><asp:Button ID="btnAddParticipant" runat="server" Text="Add Participant" OnClick="btnAddParticipant_Click"  ValidationGroup="AddParticipant" /></td>
        </tr>
        <tr>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                ControlToValidate="txtParticipantFirstName" ErrorMessage="*First Name Required" Display="Static"
               ForeColor="Red" ValidationGroup="AddParticipant"></asp:RequiredFieldValidator>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                ControlToValidate="txtParticipantLastName" ErrorMessage="*Last Name Required" Display="Static"
               ForeColor="Red" ValidationGroup="AddParticipant"></asp:RequiredFieldValidator>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server"
                ControlToValidate="txtParticipantTitle" ErrorMessage="*Title/Role Required" Display="Static"
               ForeColor="Red" ValidationGroup="AddParticipant"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
      
    <asp:Label ID="lblDisplayParticipants" runat="server" Font-Size="Larger" ForeColor="Black"></asp:Label>
    <asp:Label ID="lblError" runat="server" Font-Size="Larger" ForeColor="Red"></asp:Label>
   
    <asp:Button ID="btnCreateNewSRA" runat="server" Text="Create Risk Assessment"
                 OnClick="btnCreateNewRiskAssessment" class="float-right"/>

</asp:Content>

