using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using TodoGraphql.Models;
using TodoGraphql.Schema;
using TodoGraphql.Types;

namespace TodoGraphql.Controllers
{
    public class GraphQLController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ISchema _schema;

        public GraphQLController(
            AppDbContext db,
            ISchema schema
        )
        {
            _db = db;
            _schema = schema;
        }


        [Route("graphql")]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}