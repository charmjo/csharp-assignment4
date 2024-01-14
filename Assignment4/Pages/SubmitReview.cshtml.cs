using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace Assignment4.Pages;

public class SubmitReviewModel : PageModel
{   
    public Review? review = new Review ();
    public int genreCode {get;set;}

    public List <KeyVal> genreList = new List<KeyVal> () {
        new KeyVal {id=000, description="Computer Science, Information and General Works"},
        new KeyVal {id=100, description="Philosphy and Psychology"},
        new KeyVal {id=200, description="Religion"},
        new KeyVal {id=300, description="Social Sciences"},
        new KeyVal {id=400, description="Language"},
        new KeyVal {id=500, description="Pure Science"},
        new KeyVal {id=600, description="Technology"},
        new KeyVal {id=700, description="Arts and Recreation"},
        new KeyVal {id=800, description="Literature"},
        new KeyVal {id=900, description="History and Geography"},
    };

    private readonly ILogger<SubmitReviewModel> _logger;
    public TempDataDictionary TempData {get; set;}

    public SubmitReviewModel(ILogger<SubmitReviewModel> logger)   
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    // note to self: asp-for fields must be placed on the params. I can see why using an object is so much better.
    public IActionResult OnPost (Review review, int genreCode) {
        List<Review> reviewList = new List<Review>();
      
        // change genre description into something readable first
        review.bookInfo.genre = findDescription(genreList, genreCode);
                
        // read the file then add to list.
        string jsonStringfromFile = JsonUtils.readFile();
        if (!string.IsNullOrWhiteSpace(jsonStringfromFile)) {
            reviewList = JsonSerializer.Deserialize<List<Review>>(jsonStringfromFile);
        }

        // saving the list to the .json file
        reviewList.Add(review);
        string jsonString = JsonSerializer.Serialize(reviewList);
        JsonUtils.SaveToFile(jsonString);

        //pass the review to preview page
        string reviewJson = JsonSerializer.Serialize(review);

        Console.WriteLine(reviewJson);
        // Actually I need to pass.
        return RedirectToPage("/ViewReviews");

        /* DO NOT DELETE.
            Cannot pass complex objects, what to do? Alternative to tempData and Session:
            return RedirectToPage("/ReviewAdded", new {param = jsonString});
        */
    }

    private string findDescription (List<KeyVal> list,int id) {
        string description = "";

        foreach (var item in list)
        {
            if (item.id == id) {
                description = item.description;
            }
        }
        return description;
    }

 


}

