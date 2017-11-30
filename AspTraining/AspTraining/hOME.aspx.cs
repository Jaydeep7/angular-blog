using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AspTraining
{
    public partial class hOME : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string[] GetCity() 
        {
            string[] cities = { "London", "New York", "Paris" };
            return cities;

        }

        public  int err()
        {
            try
            {
                var a = Convert.ToInt16(TextBox1.Text);
                var b = Convert.ToInt16(TextBox2.Text);
                return a / b;
                
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
    }
}