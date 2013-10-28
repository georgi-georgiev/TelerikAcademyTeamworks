using DevSocialMe.Models;
using Error_Handler_Control;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace DevSocialMe.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ApplicationUser> GridViewAdminUsers_GetData()
        {
            var context = new ApplicationDbContext();

            IQueryable<ApplicationUser> users = null;
            try
            {
                users =
                (from u in context.Users
                 select u).OrderBy(u => u.Id);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return users;
        }

        protected void ButtonCancel_Command(object sender, CommandEventArgs e)
        {
            this.EditUserContainer.Visible = false;
        }

        protected void ButtonSaveUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new ApplicationDbContext();
                var id = e.CommandArgument.ToString();
                var user = context.Users.FirstOrDefault(u => u.Id == id);

                if (user != null)
                {
                    user.FullName = TextBoxFullName.Text;
                    user.Email = TextBoxUserEmail.Text;
                    user.UserName = TextBoxUsername.Text;
                    context.SaveChanges();
                    this.EditUserContainer.Visible = false;
                    this.DataBind();
                    ErrorSuccessNotifier.AddSuccessMessage("User was edited");
                }
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

        }

        protected void EditUserButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.EditUserContainer.Visible = true;
                var id = e.CommandArgument.ToString();
                this.ButtonSaveUser.CommandArgument = id;
                var context = new ApplicationDbContext();
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                TextBoxUsername.Text = Server.HtmlEncode(user.UserName);
                TextBoxFullName.Text = Server.HtmlEncode(user.FullName);
                TextBoxUserEmail.Text = Server.HtmlEncode(user.Email);
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}