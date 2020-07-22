using STOChernysh.Models;
using STOChernysh.Models.Repository;
using STOChernysh.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repository repository = new Repository();
            passworcnf.Visible = false;
            confirm.Visible = false;
            if (IsPostBack)
            {
                int operationCode;
                int.TryParse(Request.Form["login"],out operationCode);
                if(operationCode !=null && operationCode == 1)
                {
                    string nam = name.Value;
                    string passwor = password.Value;
                    int passid = repository.Passwords.Where(p => p.Pass == passwor).FirstOrDefault().PasswordId;
                    int logid = repository.Logins.Where(p => p.Log == nam).FirstOrDefault().LoginId;
                    if(repository.Users.Where(u=>u.Logins_LoginId == logid && u.Passwords_PasswordId == passid).ToList().Count > 0)
                    {
                        switch(repository.Users.Where(u => u.Logins_LoginId == logid && u.Passwords_PasswordId == passid).FirstOrDefault().AccountTypes_AccountTypeId)
                        {
                            case 1:
                                {
                                    FormsAuthentication.SetAuthCookie(nam, false);
                                    Response.Redirect(Request["ReturnUrl"] ?? "Orders.aspx");
                                    break;
                                }
                            case 2:
                                {
                                    FormsAuthentication.SetAuthCookie(nam, false);
                                    int id = repository.Master.Where(m => m.User_UerId == repository.Users.Where(u => u.Logins_LoginId == logid && u.Passwords_PasswordId == passid).FirstOrDefault().UserId).FirstOrDefault().MasterId;
                                    MasterHelper.MasterId = id;
                                    Response.Redirect(Request["ReturnUrl"] ?? "Master.aspx");
                                    break;
                                }
                            case 3:
                                {
                                    FormsAuthentication.SetAuthCookie(nam, false);
                                    Response.Redirect(Request["ReturnUrl"] ?? "/");
                                    break;
                                }
                        }
                    }
                }
                int.TryParse(Request.Form["register"], out operationCode);
                if (operationCode != null && operationCode == 2)
                {
                    passworcnf.Visible = true;
                    confirm.Visible = true;
                }
                int.TryParse(Request.Form["confirm"], out operationCode);
                if (operationCode != null && operationCode == 3)
                {
                    string nam = name.Value;
                    string passwor = password.Value;
                    string passcnf = passworcnf.Value;
                    if(passwor == passcnf)
                    {
                        if (repository.Logins.Where(l => l.Log == nam).ToList().Count == 0)
                        {
                            repository.AddLogin(new STOChernysh.Models.Login() { Log = nam });
                            if(repository.Passwords.Where(l => l.Pass == passwor).ToList().Count == 0)
                            {
                                repository.AddPassword(new Password() { Pass = passwor });
                   
                                repository.AddUser(new Models.User() { AccountTypes_AccountTypeId = 3, Passwords_PasswordId = repository.Passwords.Where(p => p.Pass == passwor).FirstOrDefault().PasswordId, Logins_LoginId = repository.Logins.Where(l => l.Log == nam).FirstOrDefault().LoginId });
                            }
                            else
                            {
                                repository.AddUser(new Models.User() { AccountTypes_AccountTypeId = 3, Passwords_PasswordId = repository.Passwords.Where(p => p.Pass == passwor).FirstOrDefault().PasswordId, Logins_LoginId = repository.Logins.Where(l => l.Log == nam).FirstOrDefault().LoginId });
                            }
                        }
                    }
                    passworcnf.Visible = false;
                    confirm.Visible = false;
                }

            }
        }
    }
}