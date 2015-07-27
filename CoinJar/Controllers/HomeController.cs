using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using CoinJar.Models;

namespace CoinJar.Controllers
{


    /// <summary>
    /// Home Controller is the only main controller of this application
    /// </summary>
    public class HomeController : Controller 
    {
        /// <summary>
        /// List of US Coins 
        /// </summary>
        public IEnumerable<USCoin> USCoinList
        {
            get
            {
                yield return new Cent();
                yield return new Nickel(); 
                yield return new Dime();
                yield return new Quarter();
                yield return new HalfDollar();
                yield return new Dollar();
            }
        }

        /// <summary>
        /// The main action result of application
        /// </summary>
        /// <returns>Return ActionResult as output value</returns>
        public ActionResult Index()
        {
            //Declare a US coin Jar
            USCoinJar usCoinJar = new USCoinJar();
            //Define an inline function to add multiple of coins
            Func<USCoin, byte, USCoinJar> AddCoins = (usCoin , count) =>
                {
                    for (byte i = 0; i < count ; i ++)
                        usCoinJar.Add (usCoin);
                    return usCoinJar;
                };

            //Add coins to the list of Coins in Jar
            AddCoins ( new Dollar (), 20);
            AddCoins(new HalfDollar(), 10);
            AddCoins(new Quarter(), 45);
            AddCoins(new Dime(), 15);
            AddCoins(new Cent(), 25);

            //Preparing ViewBag to render the view
            ViewBag.USCoinList = USCoinList;
            ViewBag.USCoinJar = usCoinJar;

            return View();
        }
        
    }
}
