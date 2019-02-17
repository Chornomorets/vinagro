using System;
using System.Collections.Generic;
using AspNetCoreDemoApp.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
            using (var context = new Context())
            {
                var institute = context.Institutes.Add(new Institute() { Name = "allIsOk" });
                context.SaveChanges();
            }

            return new[] { "ONPU", "ISUS" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}