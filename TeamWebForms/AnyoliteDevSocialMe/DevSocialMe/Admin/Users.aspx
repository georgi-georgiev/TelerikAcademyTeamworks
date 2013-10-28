<%@ Page Title="Edit Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DevSocialMe.Admin.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DevSocialMe all users</h1>
    <asp:GridView CssClass="table table-hover" runat="server" ID="GridViewAllUsers" ItemType="DevSocialMe.Models.ApplicationUser"
        PageSize="10" AllowPaging="true" AllowSorting="true" SelectMethod="GridViewAdminUsers_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button Text="Edit" runat="server" CommandArgument="<%#: Item.Id %>" ID="EditUserButton" OnCommand="EditUserButton_Command" CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel runat="server" ID="EditUserContainer" CssClass="editUserContainer" Visible="false">
        <div class="well">
            <h4>Edit Users </h4>
        </div>

        <asp:Label Text="Username" runat="server" ID="EditUsername" CssClass="UserLabel" />
        <asp:TextBox runat="server" ID="TextBoxUsername" />
        <br />
        <asp:Label Text="Full Name:" runat="server" ID="EditFullName" CssClass="UserLabel" />
        <asp:TextBox runat="server" ID="TextBoxFullName" />
        <br />
        <asp:Label Text="Email:" runat="server" ID="EditEmail" CssClass="UserLabel" />
        <asp:TextBox runat="server" ID="TextBoxUserEmail" />
        <br />
        <asp:Button Text="Save" runat="server" ID="ButtonSaveUser" CommandName="SaveEditedUser"
            OnCommand="ButtonSaveUser_Command" CssClass="btn btn-success" />
        <asp:Button Text="Cancel" runat="server" ID="ButtonCancel" CommandName="CancelEditUser"
            OnCommand="ButtonCancel_Command" CssClass="btn btn-warning" />
    </asp:Panel>
</asp:Content>
