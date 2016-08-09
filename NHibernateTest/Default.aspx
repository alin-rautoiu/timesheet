<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NHibernateTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <input type="number" id="txtName" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Btn_Click" Text="Inserati" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
   <columns>
          <asp:boundfield datafield="Project" headertext="Project"/>
          <asp:boundfield datafield="Task" headertext="Task"/>
          <asp:boundfield datafield="Comment" headertext="Comment"/>
          <asp:boundfield datafield="Sun" headertext="Sun"/>
          <asp:boundfield datafield="Mon" headertext="Mon"/>
          <asp:boundfield datafield="Tue" headertext="Tue"/>
          <asp:boundfield datafield="Wed" headertext="Wed"/>
          <asp:boundfield datafield="Thu" headertext="Thu"/>
          <asp:boundfield datafield="Fri" headertext="Fri"/>
          <asp:boundfield datafield="Sat" headertext="Sat"/>

        </columns>
    </asp:GridView>
    
    <p>Project:<input type="text" id="project" runat="server" /></p>
    <asp:Button ID="SubmitProject" runat="server" OnClick="SubmitProject_Click" Text="Submit" />
    <p>Task:<input type="text" id="task" runat="server" /></p>
    <p>ProjectId:<input type="number" id="projectid" runat="server" /></p>
    <asp:Button ID="SubmitTask" runat="server" OnClick="SubmitTask_Click" Text="Submit" />
    <p>UserId:<input type="number" id="userid" runat="server" /></p>
    <p>Comment:<input type="text" id="comment" runat="server" /></p>
    <p>TaskId:<input type="number" id="taskid" runat="server" /></p>
    <asp:Button ID="SubmitTimeSheet" runat="server" OnClick="SubmitTimeSheet_Click" Text="Submit" />
         <p> Data:<input type="datetime" id="data" runat="server" /></p>
    <p>WorkedHour:<input type="number" id="workedhour" runat="server" /></p>
    <p>TimeSheetId:<input type="number" id="timesheetid" runat="server" /></p>
   <asp:Button ID="SubmitDaySheet" runat="server" OnClick="SubmitDaySheet_Click" Text="Submit" />
       
</asp:Content>


