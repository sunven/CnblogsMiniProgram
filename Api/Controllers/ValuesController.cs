using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET api/values
        [HttpGet]
        public object Get()
        {
            var client = _httpClientFactory.CreateClient("wcf.open.cnblogs");
            var content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = client.GetAsync("news/hot/10");
            response.Result.EnsureSuccessStatusCode();
            var xmlStr = response.Result.Content.ReadAsStringAsync().Result;
            var doc = new XmlDocument();
            doc.LoadXml(xmlStr);
            var nameSpace = new XmlNamespaceManager(doc.NameTable);
            nameSpace.AddNamespace("space", "http://www.w3.org/2005/Atom");
            var nodes = doc.DocumentElement.SelectNodes("space:entry", nameSpace);
            var list = new List<EntryModel>();
            foreach (XmlNode xmlNode in nodes)
            {
                list.Add(new EntryModel
                {
                    Id = xmlNode.SelectSingleNode("space:id", nameSpace).InnerText,
                    Title = xmlNode.SelectSingleNode("space:title", nameSpace).InnerText,
                    Summary = xmlNode.SelectSingleNode("space:summary", nameSpace).InnerText,
                    Published = xmlNode.SelectSingleNode("space:published", nameSpace).InnerText,
                    Updated = xmlNode.SelectSingleNode("space:updated", nameSpace).InnerText,
                    Link = xmlNode.SelectSingleNode("space:link", nameSpace).Attributes["href"].InnerText,
                    Diggs = xmlNode.SelectSingleNode("space:diggs", nameSpace).InnerText,
                    Views = xmlNode.SelectSingleNode("space:views", nameSpace).InnerText,
                    Comments = xmlNode.SelectSingleNode("space:comments", nameSpace).InnerText,
                    TopicIcon = xmlNode.SelectSingleNode("space:topicIcon", nameSpace).InnerText,
                    SourceName = xmlNode.SelectSingleNode("space:sourceName", nameSpace).InnerText
                });
            }
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
