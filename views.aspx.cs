using System;


public partial class views : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["feedback"].ToString() == "")
        {
            displayResults.Text = Session["views"].ToString();
        }
        else
        {
            displayResults.Text = "feedback Placed: " + Session["feedback"].ToString() 
            + Environment.NewLine + "User's Feedback" + Session["views"].ToString();
        }
    }
}