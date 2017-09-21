using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("MyController")]
    public class MyController : BlobController<Foo>
    {        
    }
    

    [RoutePrefix("Blob")]
    public abstract class BlobController<T> : ApiController
    {
        /// <summary> Get a Bad Blob </summary>
        [Route("GetBad")]
        public string GetBad(Guid id, int? includes = null)
        {
            return "Bad";
        }

        /// <summary> Get an Ok Blob </summary>
        [Route("GetOk")]
        public string GetOk(Guid id, int includes = 0)
        {
            return "Ok";
        }
    }

    public class Foo
    {

    }
}
