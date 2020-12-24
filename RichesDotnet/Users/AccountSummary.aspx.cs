﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_AccountSummary : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Based on the users roll, use the appropriate master (which includes more or less menu items)
        if (User.IsInRole("admin"))
        {
            this.Page.MasterPageFile = "~/Admin/AdminMaster.master";
        }
        else
        {
            this.Page.MasterPageFile = "~/Users/UsersMaster.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("admin"))
        {
            //Fill out the Account Summary table
            GridView1.DataSource = DataAccess.AccountDB.GetAllAccountData();
            GridView1.DataBind();
        }
        else
        {
            //Fill out the Account Summary table
            GridView1.DataSource = DataAccess.AccountDB.GetAccountDataForUser(User.Identity.Name);
            GridView1.DataBind();
        }

    }
}