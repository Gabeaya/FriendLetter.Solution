using Microsoft.AspNetCore.Mvc;//provides access to controller class systems that are prebuild with asp.net core
using FriendLetter.Models; //allows the model to be available to our controller
namespace FriendLetter.Controllers//folder naming convention duh
{
  public class HomeController : Controller//the colon denotes inheritance of the controller functionality that asp.net provides
  {

    [Route("/hello")]//localhost:5000/hello
    public string Hello() { return "Hello friend!"; }

    [Route("/goodbye")]//localhost:5000/goodbye
    public string Goodbye() { return "Goodbye friend."; }
    //below is our root path: which requires no path appending
    //returns our view folder
    // [Route("/")]//the "/" denotes home
    // public ActionResult Letter() { return View(); }
    [Route("/")]
    public ActionResult Letter()
    {
      LetterVariable myLetterVariable = new LetterVariable();//instantiate our class
      myLetterVariable.Recipient = "Taylor";//sets a value to our recipient property
      myLetterVariable.Sender = "Gabriel";//sets a sender property value to our 
      return View(myLetterVariable); //returns our value into the Recipient variable into the view
    }
    [Route("/form")]// localhost:5000/form
    public ActionResult Form() //allows us to return our form page in the viewpoint
    { return View(); }

    [Route("/postcard")]//the location where the info from form is sent
    public ActionResult Postcard(string recipient, string sender)//we pass in the values of our forms name attributes
    {
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = recipient;
      myLetterVariable.Sender = sender;
      return View(myLetterVariable);
    }
    //action result is a built in mvc function that handles rendering
    //this line tells us to look for the letter funtion in our view folder

    // public string Hello() { return "Hello friend!"; }
    // //the method above acts as a route and will create a path(pattern) to our url
    // //www.thisapplicationurl.com/hello
  
    // public string Goodbye() { return "Goodbye friend."; }
  }
}