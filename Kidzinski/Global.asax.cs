using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Kidzinski
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["app"] = new ArrayList();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                return;

            var AK_logged = (ArrayList)Application["app"];

            Application.Lock();
            for (int i = 0; i < AK_logged.Count; i++)
                if (((string[])AK_logged[i])[0] == (String)Session["user"])
                    AK_logged.RemoveAt(i);

            Application["app"] = AK_logged;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}