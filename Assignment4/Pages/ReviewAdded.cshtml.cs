using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment4.Pages;

public class ReviewAddedModel : PageModel
{
    public Review? _review {get;set;}
    private readonly ILogger<ReviewAddedModel> _logger;

    public ReviewAddedModel(ILogger<ReviewAddedModel> logger)
    {
        _logger = logger;
    }
    public void OnGet(string reviewJson)
    {
        this._review = JsonSerializer.Deserialize<Review>(reviewJson); 
    }
    
}