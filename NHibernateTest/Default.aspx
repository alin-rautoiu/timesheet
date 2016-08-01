<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NHibernateTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataGrid
        UseAccessibleHeader="True" 
        CssClass="table table-striped table-hover"
        runat="server" ID="grdTimesheet"
        AutoGenerateColumns="False"
        OnEditCommand="grdTimesheet_OnEditCommand"
        OnUpdateCommand="grdTimesheet_OnUpdateCommand">
        <Columns>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <%#Container.ItemIndex + 1%>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn HeaderText="Nume" DataField="Name" ReadOnly="True"/>
            <asp:BoundColumn HeaderText="Data" DataField="Date" ReadOnly="True"/>
            <asp:BoundColumn HeaderText="Ore" DataField="Hours">
            </asp:BoundColumn>
            <asp:EditCommandColumn EditText="Editează" UpdateText="Actualizează"/>
        </Columns>
    </asp:DataGrid>
    
    <asp:Button runat="server" ID="btnAddItem" CssClass="button"/>
</asp:Content>

