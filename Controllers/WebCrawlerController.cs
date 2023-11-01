using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace WebCrawlerExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebCrawlerController : Controller
    {
        private readonly ILogger<WebCrawlerController> _logger;
        public WebCrawlerController(ILogger<WebCrawlerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get(string address)
        {
            var linkList = new List<string>();

            HtmlWeb site = new HtmlWeb();
            HtmlDocument htmlDocument = site.Load(address);
            
            foreach (HtmlNode link in htmlDocument.DocumentNode.SelectNodes("//a[@class='slick-item-jobs-box']"))
            {
                string hrefValue = link.GetAttributeValue("href", string.Empty);
                linkList.Add(hrefValue);
            }

            return linkList;
        }
    }
}
