using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;

// putting reading and storing to a json file in one class. I did not put reading and serializing here as it only involves one line which is overkill.
public static class JsonUtils {
    public static string readFile () {
      string str_directory = Environment.CurrentDirectory;
      string filePath = str_directory+@"/Storage"+@"/reviews.json";
      string json = "";

      if (!File.Exists(filePath)) {
         return json = "";
      }

      FileStream fs = null;

       try {
         fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

         StreamReader sr = new StreamReader(fs);
         string aLine = sr.ReadLine();
         json = aLine;
         sr.Close();

         
      } catch (IOException ioe) {
         Console.WriteLine(ioe.ToString());
      } finally {
         fs.Close();      
      }

      return json;

    }

   public static void SaveToFile (string reviewToStore) {
      // finding the parent directory - https://stackoverflow.com/questions/11542218/get-parent-directory-of-parent-directory
      // https://stackoverflow.com/questions/6875904/how-do-i-find-the-parent-directory-in-c
      
      string str_directory = Environment.CurrentDirectory;
      string json = "";
     
      //notes to self: @ is used for verbatim backslashes, meaning it could be either /,\\ 
      // create directory if did not exist
      string dir = str_directory+@"/Storage";  
      if (!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
      } 

      string filePath = dir + @"/reviews.json";

      // create file if did not exist.
      // Issue: error trap why I keep getting an exception when a json file does not exist. I was stuck solving this issue for more than 5 hours.
      // Reason:  I didn't know file.Create opens a stream. Stream has to be closed. This is now fixed.
      if(!File.Exists(filePath)) {
         File.Create(filePath).Dispose();
      } 

      if(File.Exists(filePath)){
         FileStream fs = null;
         try {
            fs = new FileStream(filePath, 
                              FileMode.OpenOrCreate, 
                              FileAccess.ReadWrite);

            StreamWriter sw = new StreamWriter(fs);
            sw.Write(reviewToStore);
            sw.Close();
            
         
         } catch (IOException ioe) {
            throw;
         } finally {
            fs.Close();
         }
      }
      


   }
}