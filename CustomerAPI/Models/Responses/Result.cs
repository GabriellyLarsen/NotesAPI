using System.Net;

namespace NotesAPI.Models.Responses
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; } 
        public string Message { get; set; }

    }
}
