﻿namespace DashboardAPI.Getway
{
    public class ErrorLogger
    {

        public void GetErrorMessage(string message, string dalName, string lineNumber)
        {
            string body = "Dear Sir," +
                          Environment.NewLine +
                          Environment.NewLine +
                          "Problem Description: " + message +
                          Environment.NewLine +
                          Environment.NewLine +
                          "Form Name: " + dalName + " ," +
                          Environment.NewLine +
                          Environment.NewLine +
                          "Line Number: " + lineNumber + "," +
                          Environment.NewLine +
                          Environment.NewLine +
                          "Note: This is an automated Email. Do not reply.";
            // _mailer.SendMail("maaz@squaregroup.com", "Error", body);
        }
        //public void GetErrorMessage(string message)
        //{
        //    _mailer.SendMail("maaz@squaregroup.com", "Error", message);
        //}
    }
}
