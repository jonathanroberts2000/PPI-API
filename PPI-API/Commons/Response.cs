namespace PPI_API.Commons
{
    using System.Collections.Generic;

    public class Response<T>
    {
        public T Data { get; set; }
        public List<Error> Errors { get; set; }
    }
}