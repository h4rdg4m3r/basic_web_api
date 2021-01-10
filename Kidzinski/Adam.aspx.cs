using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Kidzinski
{
    public partial class Adam : System.Web.UI.Page
    {
        protected string[] AK_user = new string[6];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                Validate();
        }

        protected void Username_TextChange(object sender, EventArgs e)
        {
            Error_username.Validate();
            if (Error_username.IsValid && Error_login.IsValid && Username.Text != "")
            {
                if (IsPostBack)
                    Login_addUser();
                Username.Enabled = false;
                Birthday.Enabled = true;
                Street.Enabled = true;
                House.Enabled = true;
                City.Enabled = true;
                Postal.Enabled = true;
                Postal.Enabled = true;
                Username.CssClass = "input intput2";
            }
            else
                Username.CssClass = "input intput2 input_invalid"; 
        }

        protected void Street_TextChange(object sender, EventArgs e)
        {
            if (!list.SelectedValue.Equals((string)Session["user"]))
                return;

            Error_street.Validate();
            if (Error_street.IsValid && Street.Text != "")
            {
                Street.CssClass = "input";
                updateUserInfo();
            }
            else
                Street.CssClass = "input input_invalid";
        }

        protected void House_TextChange(object sender, EventArgs e)
        {
            if (!list.SelectedValue.Equals((string)Session["user"]))
                return;

            Error_house.Validate();
            if (Error_house.IsValid && House.Text != "")
            {
                House.CssClass = "input";
                updateUserInfo();
            }
            else
                House.CssClass = "input input_invalid";
        }

        protected void City_TextChange(object sender, EventArgs e)
        {
            if (!list.SelectedValue.Equals((string)Session["user"]))
                return;

            Error_city.Validate();
            if (Error_city.IsValid && City.Text != "")
            {
                City.CssClass = "input";
                updateUserInfo();
            }
            else
                City.CssClass = "input input_invalid";
        }

        protected void Postal_TextChange(object sender, EventArgs e)
        {
            if (!list.SelectedValue.Equals((string)Session["user"]))
                return;

            Error_postal.Validate();
            if (Error_postal.IsValid && Postal.Text != "")
            {
                Postal.CssClass = "input";
                updateUserInfo();
            }
            else
                Postal.CssClass = "input input_invalid";
        }

        protected void Date_value_textchange(object source, ServerValidateEventArgs args)
        {
            if (!list.SelectedValue.Equals((string)Session["user"]))
                return;

            Error_birthday.Validate();
            if (Error_birthday.IsValid && Birthday.Text != "")
            {
                DateTime AK_temp1 = DateTime.Now;
                DateTime AK_temp2 = DateTime.ParseExact(Birthday.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                TimeSpan AK_ts = AK_temp2 - AK_temp1;
                int AK_days = AK_ts.Days;
                if (AK_days >= 0)
                {
                    args.IsValid = false;
                    Error_birthday_value.ErrorMessage = "Data jest nie z przeszłości";
                    Birthday.CssClass = "input input_invalid";
                }
                else
                {
                    args.IsValid = true;
                    Birthday.CssClass = "input";
                    updateUserInfo();
                }
            }
            else
                Birthday.CssClass = "input input_invalid";
        }

        protected void updateUserInfo()
        {
            if (!(list.SelectedValue.Equals((string)Session["user"]) && list.SelectedValue.Equals((string)Session["prevUser"])))
                return;

            string AK_User = (string) Session["user"];
            ArrayList AK_logged = (ArrayList)Application["app"];
            if (AK_logged == null || AK_User == null)
                return;
            foreach(string[] AK_tmpusr in AK_logged)
            {
                if (AK_tmpusr[0].Equals(AK_User))
                {
                    AK_tmpusr[1] = Birthday.Text;
                    AK_tmpusr[2] = Street.Text;
                    AK_tmpusr[3] = House.Text;
                    AK_tmpusr[4] = City.Text;
                    AK_tmpusr[5] = Postal.Text;

                    bool AK_IsFilled = true;
                    foreach(string AK_temp in AK_tmpusr)
                        AK_IsFilled = AK_IsFilled && (!AK_temp.Equals(""));
                    list.Enabled = AK_IsFilled;
                    refresh.Enabled = AK_IsFilled;
                    return;
                }
            }
        }

        protected void list_update(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                return;

            ArrayList AK_logged = (ArrayList)Application["app"];
            string AK_selected = list.SelectedValue;

            list.Items.Clear();
            foreach (string[] tmpuser in AK_logged)
                list.Items.Add(tmpuser[0]);
            if (!AK_selected.Equals(""))
                list.SelectedValue = AK_selected;

            refresh_buttons(AK_logged);
        }

        protected void list_update(string username)
        {
            ArrayList AK_logged = (ArrayList)Application["app"];

            list.Items.Clear();
            foreach (string[] tmpuser in AK_logged)
                list.Items.Add(tmpuser[0]);
            list.SelectedValue = username;

            refresh_buttons(AK_logged);
        }

        protected void Login_addUser()
        {
            string[] info = new string[6];
            info[0] = Username.Text;
            for (int i = 1; i < info.Length; i++)
                info[i] = "";

            Session["user"] = info[0];
            Session["prevUser"] = info[0];
            ArrayList users = (ArrayList)Application["app"];
            users.Add(info);
            Application["app"] = users;

            list_update(info[0]);

            Error_login.Enabled = false;
        }

        protected void refresh_buttons(ArrayList AK_logged)
        {
            for (int i=0; i < AK_logged.Count; i++)
            {
                if (((string[])AK_logged[i])[0] == list.SelectedValue)
                {
                    if (i == 0)
                        Button_prev.Enabled = false;
                    else
                        Button_prev.Enabled = true;

                    if (i == AK_logged.Count-1)
                        Button_next.Enabled = false;
                    else
                        Button_next.Enabled = true;

                    return;
                }
            }
        }

        protected void Next(object sender, EventArgs e)
        {
            var AK_logged = (ArrayList)Application["app"];
            Error_login.Enabled = false;
            for (int i=0; i < AK_logged.Count; i++)
                if (((string[])AK_logged[i])[0].Equals(list.SelectedValue))
                {
                    list.SelectedValue = ((string[])AK_logged[i + 1])[0];
                    user_change(((string[])AK_logged[i + 1])[0]);
                    refresh_buttons(AK_logged);
                    return;
                }
        }

        protected void Prev(object sender, EventArgs e)
        {
            var AK_logged = (ArrayList)Application["app"];
            Error_login.Enabled = false;
            for (int i = 0; i < AK_logged.Count; i++)
                if (((string[])AK_logged[i])[0].Equals(list.SelectedValue))
                {
                    list.SelectedValue = ((string[])AK_logged[i - 1])[0];
                    user_change(((string[])AK_logged[i - 1])[0]);
                    refresh_buttons(AK_logged);
                    return;
                }
        }

        protected void user_change(string username)
        {
            if (Session["user"] == null)
                return;

            ArrayList AK_logged = (ArrayList)Application["app"];
            Error_login.Enabled = false;

            foreach (string[] AK_tmpuser in AK_logged)
            {
                if (AK_tmpuser[0].Equals(username))
                {
                    values_updates(AK_tmpuser);
                    refresh_buttons(AK_logged);
                    Session["prevUser"] = AK_tmpuser[0];
                    return;
                }
            }
        }
        protected void user_change(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                return;

            ArrayList AK_logged = (ArrayList)Application["app"];
            Error_login.Enabled = false;
    
            foreach (string[] AK_tmpuser in AK_logged)
            {
                if (AK_tmpuser[0].Equals(list.SelectedValue))
                {
                    values_updates(AK_tmpuser);
                    refresh_buttons(AK_logged);
                    Session["prevUser"] = AK_tmpuser[0];
                    return;
                }
            }
        }
  
        protected void values_updates(string[] user)
        {
            Birthday.Text = user[1];
            Street.Text = user[2];
            House.Text = user[3];
            City.Text = user[4];
            Postal.Text = user[5];

            if (user[0].Equals((String)Session["user"]))
            {
                Birthday.Enabled = true;
                Street.Enabled = true;
                House.Enabled = true;
                City.Enabled = true;
                Postal.Enabled = true;
            }
            else
            {
                Birthday.Enabled = false;
                Street.Enabled = false;
                House.Enabled = false;
                City.Enabled = false;
                Postal.Enabled = false;
            }
        }

        protected void Check_if_logged(object source, ServerValidateEventArgs args)
        {
            var AK_logged = (ArrayList)Application["app"];

            for (int i = 0; i < AK_logged.Count; i++)
            {
                if (((string[])AK_logged[i])[0] == Username.Text)
                {
                    args.IsValid = false;
                    Error_login.ErrorMessage = "Login jest juz zajety!";
                    return;
                }
            }
            args.IsValid = true;
        }
    }
}