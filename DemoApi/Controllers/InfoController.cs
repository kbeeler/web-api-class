using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

public class InfoController : ControllerBase
{
    [HttpGet("/info")]
    public async Task<ActionResult> GetTheInfo()
    {
        return Ok($"The Controller is working just fine. created at { DateTime.Now.ToLongTimeString()}");
    }
    [HttpGet("/blog/{year:int:min(2005)}/{month:int:min(1):max(12)}/{day:int}")]
    public async Task<ActionResult> GetTheBlogStuff(int year, int month, int day)
    {
        return Ok($"Showing the blog stuff for {year} {month} {day}");
    }

    [HttpGet("/colors")]
    public async Task<ActionResult> GetColors([FromQuery]string color = "Blue")
    {
        return Ok($"You picked {color}");
    }


    [HttpGet("/employees")]
    public async Task<ActionResult> GetEmployees([FromQuery] string department = "All")
    {
        var employees = new List<Employee>
        {
            new Employee("Bob Smith", "dev"),
            new Employee("Joe Jones", "dev"),
            new Employee("Sue Blue", "ceo")
        };
        if (department != "All")
        {
            var response = employees.Where(e => e.Department == department).ToList();
            return Ok(new ResponseType<List<Employee>>(response, department));
        }
        return Ok(new ResponseType<List<Employee>>(employees, department));
    }

    [HttpGet("/employees")]
    public async Task<ActionResult> GetEmployees([FromQuery] string department = "All")
    {

    }


public record ResponseType<T>(T data, string Filter);
public record Employee(string Name, string Department);

public record CreateBugReportRequest
{

}
