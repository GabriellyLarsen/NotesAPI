using Microsoft.AspNetCore.Mvc;
using NotesAPI.Context;
using NotesAPI.Enums;
using NotesAPI.Models.Requests;
using NotesAPI.Models.Responses;
using System.Diagnostics;

namespace NotesAPI.Controllers
{
    public class NotesController: ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public NotesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(CreateNotesRequest noteRequest)
        {
            bool validation = GetValidationResult(noteRequest);

            if (!validation)
            {
                CreateNotesResponse createNotesResponse = new CreateNotesResponse()
                {
                    ResultCode = "ERROR",
                    Message = "Invalid request"

                };
                return StatusCode(StatusCodes.Status400BadRequest, createNotesResponse);
            }

            //later the response will come from the DB
            //we will need a mapper here as well to set the DB info as CreateNotesResponse
            //for now, a dummy response

            CreateNotesResponse response = new CreateNotesResponse()
            {

            };

            return new CreatedResult(string.Empty, response);
        }

        private bool GetValidationResult(CreateNotesRequest noteRequest)
        {
            bool isValid = true;

            Category category = noteRequest.Category; 
            string title = noteRequest.Title;
            DateTime? targetDate = noteRequest.TargetDate;

            if (string.IsNullOrEmpty(category.ToString()) || string.IsNullOrEmpty(title) || !targetDate.HasValue)
            {
                isValid = false;
            }

            return isValid;
        }

    }
}
