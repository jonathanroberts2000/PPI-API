namespace PPI_API.Controllers
{
    using System.Net;
    using System.Linq;
    using PPI_API.Commons;
    using PPI_Model.Models;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class BaseController : ControllerBase
    {
        protected string UserName
        {
            get
            {
                return HttpContext.Request.Headers["UserName"].ToString();
            }
        }

        protected string Password
        {
            get
            {
                return HttpContext.Request.Headers["Password"].ToString();
            }
        }

        protected int AccountId
        {
            get
            {
                return int.Parse(HttpContext.Items["AccountId"].ToString());
            }
        }

        protected IActionResult CreateErrorResponseHelper(ValidationResult results)
        {
            if(results != null && results.Errors.Count > 0)
            {
                return StatusCode((int)HttpStatusCode.PreconditionRequired, new Response<object>
                {
                    Errors = results.Errors.Select(x => new Error
                    {
                        Field = x.PropertyName,
                        Code = x.ErrorCode,
                        Message = x.ErrorMessage
                    }).ToList()
                });
            }
            else
            {
                return BadRequest();
            }
        }

        protected IActionResult CreateErrorRulesResponseHelper(List<KeyValuePair<string, ErrorModel>> errors)
        {
            Response<object> response = new()
            {
                Errors = errors.Select(x => new Error
                {
                    Field = x.Key,
                    Code = x.Value.ErrorCode,
                    Message = x.Value.Message
                }).ToList()
            };

            return StatusCode((int)HttpStatusCode.PreconditionFailed, response);
        }

        protected IActionResult CreateResponseHelper<T>(T response, HttpStatusCode statusCode, int id = 0)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Created:
                    return Created($"/{id}", new Response<T> { Data = response });
                case HttpStatusCode.NoContent:
                    HttpContext.Response.Headers.Add("Location", $"/{id}");
                    return NoContent();
                case HttpStatusCode.OK:
                    return Ok(response);
                default:
                    return Ok();
            }
        }
    }
}