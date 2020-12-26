using System;
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Validate();
        }
        protected void Username_TextChange(object sender, EventArgs e)
        {
            Error_username.Validate();
            if(Error_username.IsValid && Username.Text != "")
            {
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
            Error_street.Validate();
            if (Error_street.IsValid && Street.Text != "")
                Street.CssClass = "input";
            else
                Street.CssClass = "input input_invalid";
        }

        protected void House_TextChange(object sender, EventArgs e)
        {
            Error_house.Validate();
            if (Error_house.IsValid && House.Text != "")
                House.CssClass = "input";
            else
                House.CssClass = "input input_invalid";
        }
        protected void City_TextChange(object sender, EventArgs e)
        {
            Error_city.Validate();
            if (Error_city.IsValid && City.Text != "")
                City.CssClass = "input";
            else
                City.CssClass = "input input_invalid";
        }
        protected void Postal_TextChange(object sender, EventArgs e)
        {
            Error_postal.Validate();
            if (Error_postal.IsValid && Postal.Text != "")
                Postal.CssClass = "input";
            else
                Postal.CssClass = "input input_invalid";
        }
        protected void Date_value_textchange(object source, ServerValidateEventArgs args)
        {
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
                }   
            }
            else
                Birthday.CssClass = "input input_invalid";
        }
    }
}