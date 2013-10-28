<%@ Page Title="Edit Skills" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Skills.aspx.cs" Inherits="DevSocialMe.Admin.Skills" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DevSocialMe User skills</h1>

    <asp:GridView CssClass="table table-hover skillsTable" runat="server" ID="GridViewAllSkills" DataKeyNames="SkillId"
        ItemType="DevSocialMe.Models.Skill" PageSize="10" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewAllSkills_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink CssClass="navbar-link" ID="HyperLink1" runat="server"
                        NavigateUrl='<%#: String.Format("SkillEdit.aspx?id={0}", Item.SkillId) %>' Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
