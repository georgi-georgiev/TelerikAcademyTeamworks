using DevSocialMe.Models;
using Error_Handler_Control;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevSocialMe.Admin
{
    public partial class Skills : Page
    {
        public IQueryable<Skill> GridViewAllSkills_GetData()
        {
            var context = new ApplicationDbContext();

            IOrderedQueryable<Skill> allSkills = null;
            try
            {
                allSkills =
                (from s in context.Skills
                 select s).OrderBy(s => s.SkillId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            return allSkills;
        }

        protected void ButtonDeleteSkill_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int skillId = Convert.ToInt32(e.CommandArgument);
                ApplicationDbContext context = new ApplicationDbContext();
                var selectedSkill = context.Skills.FirstOrDefault(s => s.SkillId == skillId);
                context.Skills.Remove(selectedSkill);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Skill Deleted!");
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}