<%@ Page Title="Standards and Guidelines" Language="C#" AutoEventWireup="true" 
    CodeBehind="StandardsGuideLines.aspx.cs" Inherits="SRA.StandardsGuideLines" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>Standards and Guidelines</h2>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <p>This risk assessment calculator provides a means for determining risks associated with industrial machinery. Risk assessments should be carried out in accordance with EN ISO 12100:2010 Safety of Machinery. General Principles of Design. Risk Assessment and Risk Reduction.</p>
    <p>Assumptions are based sufficient training of machinery operators and maintenance personnel.</p>
    <table>
        <tr><th colspan="2">Severity</th></tr>
        <tr>
            <td>0.1</td>
            <td>Scratch or bruise</td>
        </tr>
        <tr>
            <td>0.5</td>
            <td>Laceration or mild ill-effect</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Break of a minor bone or temporary minor illness</td>
        </tr>
        <tr>
            <td>4</td>
            <td>Break a major bone or temporary serious illness</td>
        </tr>
        <tr>
            <td>6</td>
            <td>Loss of one limb, eye, or permanent hearing loss</td>
        </tr>
        <tr>
            <td>10</td>
            <td>Loss of two limbs or both eyes</td>
        </tr>
        <tr>
            <td>15</td>
            <td>Fatality</td>
        </tr>
    </table>        
    <table>
        <tr><th colspan="2">Likelihood of Injury</th></tr>
        <tr>
            <td>0.03</td>
            <td>Almost impossible.</td>
        </tr>
        <tr>
            <td>1</td>
            <td>Highly unlikely, but conceivable</td>
        </tr>
        <tr>
            <td>2</td>
            <td>Possible but unusual</td>
        </tr>
        <tr>
            <td>8</td>
            <td>Probably, not surprising</td>
        </tr>
        <tr>
            <td>10</td>
            <td>Likely, only to be expected</td>
        </tr>
        <tr>
            <td>15</td>
            <td>Certain</td>
        </tr>
    </table>
    <table>
        <tr>
            <th colspan="2">Frequency of Exposure</th>
        </tr>
        <tr>
            <td>0.5</td>
            <td>Annually, less than once per year</td>
        </tr>
        <tr>
            <td>1</td>
            <td>Monthly, less than once per month</td>
        </tr>
        <tr>
            <td>1.5</td>
            <td>Weekly, less than once per week</td>
        </tr>
        <tr>
            <td>2.5</td>
            <td>Daily, maximum once per day</td>
        </tr>
        <tr>
            <td>4</td>
            <td>Hourly, maximum once per hour</td>
        </tr>
        <tr>
            <td>5</td>
            <td>Constantly, more than once per hour</td>
        </tr>
    </table>
    <table>
        <tr>
            <th colspan="2">Number of People</th>
        </tr>
        <tr>
            <td>1</td>
            <td>1-2 people</td>
        </tr>
        <tr>
            <td>2</td>
            <td>3-7 people</td>
        </tr>
        <tr>
            <td>4</td>
            <td>8-15 people</td>
        </tr>
        <tr>
            <td>8</td>
            <td>16-50 people</td>
        </tr>
        <tr>
            <td>12</td>
            <td>50+ people</td>
        </tr>
    </table>
    <table>
        <tr>
            <th colspan="2">Risk Number Description</th>
        </tr>
        <tr style="color: #008000; font-weight: bold;">
            <td>0-5</td>
            <td>Negligible</td>
        </tr>
        <tr style="color: #FF9900; font-weight: bold;">
            <td>>5-50</td>
            <td>Significant</td>
        </tr>
        <tr style="color: #FF6600; font-weight: bold;">
            <td>>50-500</td>
            <td>High</td>
        </tr>
        <tr style="color: #FF0000; font-weight: bold">
            <td>>500</td>
            <td>Unacceptable</td>
        </tr>
    </table>
    <table>
        <tr><th>Types of Hazards</th></tr>
        <tr><td>Mechanical</td></tr>
        <tr><td>Electrical</td></tr>
        <tr><td>Thermal</td></tr>
        <tr><td>Noise</td></tr>
        <tr><td>Vibration</td></tr>
        <tr><td>Radiation</td></tr>
        <tr><td>Material/Substance</td></tr>
        <tr><td>Ergonomic</td></tr>
        <tr><td>Environmental</td></tr>
        <tr><td>Combination</td></tr>
    </table>
    <table>
        <tr><th>Tasks</th></tr>
        <tr><td>Transport of machinery</td></tr>
        <tr><td>Installation</td></tr>
        <tr><td>Process changeover</td></tr>
        <tr><td>Operation</td></tr>
        <tr><td>Cleaning and Maintenance</td></tr>
        <tr><td>Trouble-shooting</td></tr>
        <tr><td>Decomissioning</td></tr>
    </table>
</asp:Content>
