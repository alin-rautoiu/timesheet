<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NHibernateTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" 
        ID="ProjectGrid" 
        AutoGenerateEditButton="true"
        AutoGenerateColumns="false" 
        CausesValidation="false" OnRowDataBound = "OnRowDataBound">
        
      
    </asp:GridView>
</asp:Content>

