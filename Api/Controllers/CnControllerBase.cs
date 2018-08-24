﻿using Api.Models;
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
    public class CnControllerBase : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IHttpClientFactory HttpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public CnControllerBase(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        protected List<EntryModel> Get(string url)
        {
            var doc = GetXmlDocument(url);
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

        protected NewsBody Body(string url)
        {
            var doc = GetXmlDocument(url);
            var newsBody = new NewsBody
            {
                Title = doc.DocumentElement.SelectSingleNode("Title").InnerText,
                SourceName = doc.DocumentElement.SelectSingleNode("SourceName").InnerText,
                SubmitDate = doc.DocumentElement.SelectSingleNode("SubmitDate").InnerText,
                Content = doc.DocumentElement.SelectSingleNode("Content").InnerText,
                ImageUrl = doc.DocumentElement.SelectSingleNode("ImageUrl").InnerText,
                PrevNews = doc.DocumentElement.SelectSingleNode("PrevNews").InnerText,
                NextNews = doc.DocumentElement.SelectSingleNode("PrevNews").InnerText,
                CommentCount = doc.DocumentElement.SelectSingleNode("PrevNews").InnerText
            };
            return newsBody;
        }

        private XmlDocument GetXmlDocument(string url)
        {
            var client = HttpClientFactory.CreateClient("wcf.open.cnblogs");
            var content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = client.GetAsync(url);
            response.Result.EnsureSuccessStatusCode();
            var xmlStr = response.Result.Content.ReadAsStringAsync().Result;
            var doc = new XmlDocument();
            doc.LoadXml(xmlStr);
            return doc;
        }
    }
}