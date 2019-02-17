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
		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());

            using (var context = new Context())
            {
                var institute = context.Institutes.Add(new Institute() { Name = "" + Environment.GetEnvironmentVariable("DATABASE_URL") });
                context.SaveChanges();
                institute = context.Institutes.Add(new Institute() { Name = "" + Environment.CurrentDirectory.ToString() });
                context.SaveChanges();

            }

            return new[] { "ONPU", "ISUS" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
            List<Institute> l = new List<Institute>();
            using (var context = new Context())
            {
                var institutes = context.Institutes;
                foreach(var i in institutes)
                {

                    l.Add(i);
                    Console.WriteLine(i.Name);
                }

            }
            Console.WriteLine();
			return "value";
		}
	}
}