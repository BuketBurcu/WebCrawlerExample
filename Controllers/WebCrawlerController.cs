using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using HtmlAgilityPack;
using WebCrawlerExample.DataAccess;
using WebCrawlerExample.Models;


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
        public List<JobDataModel> Get(string address, string htmlNode)
        {
            var linkList = new List<JobDataModel>();

            HtmlWeb site = new HtmlWeb();
            HtmlDocument htmlDocument = site.Load(address);


            foreach (HtmlNode link in htmlDocument.DocumentNode.SelectNodes(htmlNode))
            {
                var jobDataModel = new JobDataModel
                {
                    CompanyName = link.SelectNodes("div/div[2]/div/span/p")[0].InnerText.Trim(),
                    JobDetail = link.SelectNodes("div/div[2]/p")[0].InnerText.Trim(),
                    Link = link.GetAttributeValue("href", string.Empty)
                };
                linkList.Add(jobDataModel);
                using (MongoRepository<JobDataModel> repository = new MongoRepository<JobDataModel>())
                    repository.Add(jobDataModel);
            }
            return linkList;
        }
    }
}
