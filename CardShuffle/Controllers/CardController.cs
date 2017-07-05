using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardShuffle.Models;
using CardShuffle.BL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardShuffle.Controllers
{
    public class CardController : Controller
    {
        CardManager _cardManager;

        public CardController()
        {
            _cardManager = new CardManager();
        }

        [Route("sort")]
        public IActionResult Sort()
        {
            return Json(ViewCard.Create(_cardManager.Sort()));
        }

        [Route("shuffle")]
        public IActionResult Shuffle()
        {
            return Json(ViewCard.Create(_cardManager.Shuffle()));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
