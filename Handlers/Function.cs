using Kira.FaaS.Core.Functions;
using Kira.FaaS.Core.Functions.Triggers;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Kira.FaaS.Sample.Funcs
{
    public class Function
    {
        #region Public Methods

        [FunctionName("my-first-function")]
        [HttpTrigger("/", "post")]
        public async Task HandleAsync(HttpContext ctx)
        {
            string name = ctx.Request.Query["name"];
            ctx.Response.StatusCode = (int)HttpStatusCode.OK;
            await ctx.Response.WriteAsync($"Hello my good frind {name}");
        }

        #endregion
    }
}
