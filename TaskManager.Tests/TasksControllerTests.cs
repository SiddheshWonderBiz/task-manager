using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers;
using TaskManager.Api.Models;

namespace TaskManager.Tests;

public class TasksControllerTests
{
    [Fact]
    public void Create_ReturnsCreatedResult()
    {
        var controller = new TasksController();
        var task = new TaskItem { Title = "Learn GitHub Actions" };

        var result = controller.Create(task);

        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public void GetAll_ReturnsOkResult()
    {
        var controller = new TasksController();

        var result = controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenTaskDoesNotExist()
    {
        var controller = new TasksController();

        var result = controller.Delete(999);

        Assert.IsType<NotFoundResult>(result);
    }
}