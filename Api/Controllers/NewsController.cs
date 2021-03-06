﻿using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : CnControllerBase
    {
        /// <summary>
        /// 热门新闻
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count}")]
        public List<NewsEntryModel> Hot(int count)
        {
            return GetNewsList("news/hot/" + count);
        }

        /// <summary>
        /// 最近新闻
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count}")]
        public List<NewsEntryModel> Recent(int count)
        {
            return GetNewsList("news/recent/" + count);
        }

        /// <summary>
        /// 推荐新闻
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("paged/{page}/{size}")]
        public List<NewsEntryModel> Recommend(int page, int size)
        {
            return GetNewsList($"news/recommend/paged/{page}/{size}");
        }

        /// <summary>
        /// 新闻内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public NewsBody Item(int id)
        {
            return Body("news/item/" + id);
        }

        /// <summary>
        /// 新闻评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("{id}/{page}/{size}")]
        public List<NewsEntryModel> Comments(int id, int page, int size)
        {
            return GetNewsList($"news/item/{id}/comments/{page}/{size}");
        }



        public NewsController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}