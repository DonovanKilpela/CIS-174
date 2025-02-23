using Microsoft.AspNetCore.Mvc;
using RazorTemplatesKilpela.Models;

namespace RazorTemplatesKilpela.ViewModel
{
    // This will represent the ViewModel for Assignment 6.1.
    public class Assignment6_1ViewModel 
    {
        // This will get or set the list of students to be displayed.
        public List<Student> Students { get; set; }

        // This will get or set the access level of the user, determining what data they can see.
        public int AccessLevel { get; set; }

        // This will get or set any error message to display if there are issues.
        public string ErrorMessage { get; set; }
    }
}
