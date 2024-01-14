using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment4.Pages;


public class IndexModel : PageModel
{
    //public Person? _person {get;set;}
    public Review? _review {get;set;}
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)   
    {
        _logger = logger;
    }

    public void OnGet()
    {
      //  JsonUtils.readFile();
    }

}
