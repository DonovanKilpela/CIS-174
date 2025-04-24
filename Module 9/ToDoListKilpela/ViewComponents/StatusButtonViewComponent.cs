using Microsoft.AspNetCore.Mvc;
using ToDoListKilpela.Models;

namespace ToDoListKilpela.ViewComponents
{
    public class StatusButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string statusId)
        {
            string btnClass = statusId switch
            {
                "todo" => "btn-secondary",
                "inprogress" => "btn-primary",
                "qa" => "btn-warning",
                "done" => "btn-success",
                _ => "btn-light"
            };

            string statusName = statusId switch
            {
                "todo" => "To Do",
                "inprogress" => "In Progress",
                "qa" => "QA",
                "done" => "Done",
                _ => "Unknown"
            };

            ViewData["BtnClass"] = btnClass;
            ViewData["StatusName"] = statusName;

            return View();
        }


    }
}
