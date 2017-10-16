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
        public enum CustomEnum
        {
            random,
            notRandom
        }

        /// <summary> Template object test </summary>
        [Route("GetTemplate")]
        public string GetTemplate(AnotherFoo<T> value)
        {
            return "Gets a template";
        }

        /// <summary> A nullable enum test </summary>
        [Route("GetEnumNull")]
        public string GetEnumNull(CustomEnum? value = null)
        {
            return "Nullable Enum parameter";
        }

        /// <summary> A non-null enum test </summary>
        [Route("GetEnumNonNull")]
        public string GetEnumNonNull(CustomEnum value)
        {
            return "Non-Null Enum parameter";
        }

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

    public class AnotherFoo<TV>
    {

    }
}
