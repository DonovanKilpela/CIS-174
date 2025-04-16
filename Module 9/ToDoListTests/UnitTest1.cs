using Xunit;
using Moq;
using ToDoListKilpela.Controllers;
using ToDoListKilpela.Models;
using ToDoListKilpela.ViewModels;
using ToDoListKilpela.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListTests
{
    public class HomeControllerTests
    {
        // Tests that the Index action returns a view with the expected number of statuses, sprints, and tickets
        // when no filters are applied.
        [Fact]
        public void Index_ReturnsViewWithExpectedCounts()
        {
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.GetStatuses()).Returns(new List<Status> { new Status { StatusId = "todo", Name = "To Do" } });
            mockRepo.Setup(r => r.GetSprintNumbers()).Returns(new List<int> { 1, 2 });
            mockRepo.Setup(r => r.GetTickets()).Returns(new List<Ticket>
            {
                new Ticket { Id = 1, Name = "Test", StatusId = "todo", SprintNumber = 1, PointValue = 10, Description = "desc", Status = new Status { StatusId = "todo", Name = "To Do" } }
            }.AsQueryable());

            var controller = new HomeController(mockRepo.Object);

            var result = controller.Index(null, null) as ViewResult;
            var model = result?.Model as TicketViewModel;

            Assert.NotNull(model);
            Assert.Single(model.Statuses);
            Assert.Equal(2, model.SprintNumbers.Count);
            Assert.Single(model.Tickets);
        }

        // Tests that the Index action filters tickets by status and returns only the matching tickets.
        [Fact]
        public void Index_FiltersByStatus_ReturnsOnlyMatchingTickets()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket { Id = 1, Name = "A", StatusId = "todo", SprintNumber = 1, Status = new Status { StatusId = "todo", Name = "To Do" } },
                new Ticket { Id = 2, Name = "B", StatusId = "done", SprintNumber = 1, Status = new Status { StatusId = "done", Name = "Done" } }
            };

            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.GetStatuses()).Returns(new List<Status> { new Status { StatusId = "todo", Name = "To Do" }, new Status { StatusId = "done", Name = "Done" } });
            mockRepo.Setup(r => r.GetSprintNumbers()).Returns(new List<int> { 1 });
            mockRepo.Setup(r => r.GetTickets()).Returns(tickets.AsQueryable());

            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Index("todo", null) as ViewResult;
            var model = result?.Model as TicketViewModel;

            // Assert
            Assert.Single(model.Tickets);
            Assert.Equal("A", model.Tickets[0].Name);
        }

        // Tests that the Index action filters tickets by sprint and returns only tickets matching the specified sprint number.
        [Fact]
        public void Index_FiltersBySprint_ReturnsOnlyMatchingTickets()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket { Id = 1, Name = "A", StatusId = "todo", SprintNumber = 1, Status = new Status { StatusId = "todo", Name = "To Do" } },
                new Ticket { Id = 2, Name = "B", StatusId = "todo", SprintNumber = 2, Status = new Status { StatusId = "todo", Name = "To Do" } }
            };

            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.GetStatuses()).Returns(new List<Status> { new Status { StatusId = "todo", Name = "To Do" } });
            mockRepo.Setup(r => r.GetSprintNumbers()).Returns(new List<int> { 1, 2 });
            mockRepo.Setup(r => r.GetTickets()).Returns(tickets.AsQueryable());

            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Index(null, "2") as ViewResult;
            var model = result?.Model as TicketViewModel;

            // Assert
            Assert.Single(model.Tickets);
            Assert.Equal("B", model.Tickets[0].Name);
            Assert.Equal(2, model.Tickets[0].SprintNumber);
        }

        // Tests that the Add action returns the same view with the model when the model is invalid.
        [Fact]
        public void Add_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.GetStatuses()).Returns(new List<Status>());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Required");

            var ticket = new Ticket();

            // Act
            var result = controller.Add(ticket) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticket, result.Model);
        }

        // Tests that the Edit action returns the correct ticket for editing.

        [Fact]
        public void Edit_Get_ReturnsCorrectTicket()
        {
            // Arrange
            var ticket = new Ticket { Id = 1, Name = "Test" };
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.GetTicketById(1)).Returns(ticket);
            mockRepo.Setup(r => r.GetStatuses()).Returns(new List<Status>());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Edit(1) as ViewResult;
            var model = result?.Model as Ticket;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        // Tests that the Delete action removes the ticket and redirects to the Index action.
        [Fact]
        public void Delete_RemovesTicketAndRedirects()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(r => r.DeleteTicket(1));
            mockRepo.Setup(r => r.Save());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Delete(1) as RedirectToActionResult;

            // Assert
            mockRepo.Verify(r => r.DeleteTicket(1), Times.Once);
            mockRepo.Verify(r => r.Save(), Times.Once);
            Assert.Equal("Index", result.ActionName);
        }

    }
}
