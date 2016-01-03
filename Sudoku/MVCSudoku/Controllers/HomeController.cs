using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wrapper;

namespace MVCSudoku.Controllers
{
    public class HomeController : Controller
    {
        static SudokuWrapper wrapper = new SudokuWrapper();
        public ActionResult Index()
        {
            return View(wrapper);
        }

        [ActionName("Validate")]
        public string Validate(int x, int y, int value)
        {
            Debug.WriteLine(x + " " + y + " " + value);
            if (wrapper.SetValue(y, x, value))
            {
                Debug.WriteLine("SetValue success");
                if (wrapper.isValid())
                {
                    Debug.WriteLine("Field is valid");
                    if (wrapper.isFinished())
                    {
                        Debug.WriteLine("Finished!");
                        return "{ \"status\": \"" + "Finished" + "\" }";
                    }
                    return "{ \"status\": \"" + "Valid" + "\" }";
                }
                return "{ \"status\": \"" + "Failed to validate" + "\" }";
            }
            return "{ \"status\": \"" + "Failed to set value" + "\" }";
        }

        [ActionName("NewGame")]
        public ActionResult NewGame()
        {
            wrapper = new SudokuWrapper();
            return RedirectToAction("Index");
        }

        [ActionName("Cheat")]
        public ActionResult Cheat()
        {
            wrapper.Cheat();
            return RedirectToAction("Index");
        }
    }
}