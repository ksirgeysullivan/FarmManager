using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmFinanceWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private string valueFromUser;
        private int testInt;

        protected void Page_Load(object sender, EventArgs e)
        {
            valueFromUser = PhoneTextBox.Text;
            testInt = 32;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string acceptedCharacter = "()-";

            string possiblePhoneNumber = PhoneTextBox.Text.Trim();

            bool isPhoneNumber = true;
            foreach( char thisChar in possiblePhoneNumber)
            {
                if (( !acceptedCharacter.Contains(thisChar)) && (!Char.IsDigit(thisChar)))
                {
                    isPhoneNumber = false;
                    break;
                }
            }

            if (isPhoneNumber)
                ResponseLabel.Text = "Looks good!";
            else
                ResponseLabel.Text = "Not a valid phone number";


        }
    }
}