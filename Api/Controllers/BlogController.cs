using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : CnControllerBase
    {
        /// <summary>
        /// 48小时阅读排行
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count}")]
        public List<BlogEntryModel> FortyeightHoursTopViewPosts(int count)
        {
            return GetBlogList("blog/48HoursTopViewPosts/" + count);
        }

        /// <summary>
        /// 十天推荐排行
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count}")]
        public List<BlogEntryModel> TenDaysTopDiggPosts(int count)
        {
            return GetBlogList("blog/TenDaysTopDiggPosts/" + count);
        }

        /// <summary>
        /// 最近
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{count}")]
        public List<BlogEntryModel> Recent(int count)
        {
            return GetBlogList("blog/sitehome/recent/" + count);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("{page}/{size}")]
        public List<BlogEntryModel> Paged(int page, int size)
        {
            return GetBlogList($"blog/sitehome/paged/{page}/{size}");
        }

        /// <summary>
        /// 博客内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Body(int id)
        {
            var doc = GetXmlDocument("blog/post/body/" + id);
            return doc.DocumentElement.InnerText;
        }

        /// <summary>
        /// 博客评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("{id}/{page}/{size}")]
        public List<BlogEntryModel> Comments(int id, int page, int size)
        {
            return GetBlogList($"blog/post/{id}/comments/{page}/{size}");
        }

        public BlogController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}