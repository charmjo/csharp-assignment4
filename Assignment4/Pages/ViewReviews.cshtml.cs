using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Assignment4.Pages;

public class ViewReviews : PageModel
{
    public Review? _review {get;set;}
    public List<Review>? reviewList;
    private readonly ILogger<ViewReviews> _logger;

    public ViewReviews(ILogger<ViewReviews> logger)
    {
        _logger = logger;
    }
    
    // please use the submitReview to add views since this will initially be empty.
    public void OnGet()
    {
        string jsonStringfromFile = JsonUtils.readFile();

        if (!string.IsNullOrWhiteSpace(jsonStringfromFile)) {
            reviewList = JsonSerializer.Deserialize<List<Review>>(jsonStringfromFile);
        }
    }
    
}