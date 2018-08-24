using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Api.Filters
{
    public class ResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                context.Result = objectResult.Value == null ? new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" }) : new ObjectResult(new { code = 200, msg = "", result = objectResult.Value });
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
            }
            else if (context.Result is ContentResult)
            {
                context.Result = new ObjectResult(new { code = 200, msg = "", result = (context.Result as ContentResult).Content });
            }
            else if (context.Result is StatusCodeResult)
            {
                context.Result = new ObjectResult(new { code = ((StatusCodeResult) context.Result).StatusCode, sub_msg = "", msg = "" });
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}