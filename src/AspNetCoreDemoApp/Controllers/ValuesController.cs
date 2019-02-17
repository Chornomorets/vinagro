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

            var builder = new PostgreSqlConnectionStringBuilder("postgres://idjwltepabhcst:1b36a53486fd99f4549577a743a0a25292089b5b88b22c6505a23d97b4e394b2@ec2-79-125-4-96.eu-west-1.compute.amazonaws.com:5432/de0ehmmkkm4sns")
            {
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Require
            };

            using (var context = new Context())
            {
                var institute = context.Institutes.Add(new Institute() { Name = "" + DateTime.Now });
                context.SaveChanges();
            }

            return new[] { "ONPU", "ISUS" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{

            using (var context = new Context())
            {
                var institutes = context.Institutes;
                foreach(var i in institutes)
                {
                    Console.WriteLine(i.Name);
                }
            }
            Console.WriteLine();
			return "value";
		}
	}
}