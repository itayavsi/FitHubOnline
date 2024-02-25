using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ItayProject.WebPages
{
    public partial class registration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your page load logic here, if needed
        }

        protected bool ValidateForm()
        {
            string firstNameValue = firstName.Value;
            string lastNameValue = lastName.Value;
            string emailValue = email.Value;
            string phoneValue = phone.Value;
            string userNameValue = userName.Value;
            string passwordValue = password.Value;

            // Example validation: Check if required fields are filled
            if (string.IsNullOrEmpty(firstNameValue) || string.IsNullOrEmpty(lastNameValue) ||
                string.IsNullOrEmpty(emailValue) || string.IsNullOrEmpty(phoneValue) ||
                string.IsNullOrEmpty(userNameValue) || string.IsNullOrEmpty(passwordValue))
            {
                // Display an error message or handle the validation failure
                message.InnerHtml = ("All fields are required!");
                return false;
            }

            if (!char.IsLetter(firstNameValue[0]))
            {
                message.InnerHtml = ("First name must start with a letter!");
                return false;
            }
            if (!IsValidEmail(emailValue))
            {
                message.InnerHtml = ("Invalid email format!");
                return false;
            }

            if (!IsValidPhoneNumber(phoneValue))
            {
                message.InnerHtml = ("Invalid phone number format!");
                return false;
            }
            return true;

        }

       public User GetUser()
        {
            User user = new User();
            user.FirstName = firstName.Value;
            user.LastName = lastName.Value;
            user.Email = email.Value;
            user.Phone = Convert.ToInt32(phone.Value);
            user.UserName = userName.Value;
            user.Password = password.Value;
            return user;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }
           User user = GetUser();
            Helper.Insert(user);
            Response.Redirect("index.aspx");
        }

        // Example email validation using regular expression
        private bool IsValidEmail(string email)
        {
            const string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Example phone number validation using regular expression
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            const string phonePattern = @"^\d{10}$"; // Assuming a 10-digit phone number
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
    }
}