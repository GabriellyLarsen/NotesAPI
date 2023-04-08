using Microsoft.AspNetCore.Mvc;
using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Requests;
using NotesAPI.Models.Responses;
using NotesAPI.Services;
using NotesAPI.Services.Mappers;

namespace NotesAPI.Controllers
{
    public class NotesController: ControllerBase
    {
        private readonly IServiceProviderHandler _serviceProviderHandler;
        private readonly ICreateNoteRequestMapper _createNoteRequestMapper;
        public NotesController(IServiceProviderHandler serviceProviderHandler) 
        { 
            _serviceProviderHandler = serviceProviderHandler;
            _createNoteRequestMapper = _serviceProviderHandler.GetRequiredService<ICreateNoteRequestMapper>();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(CreateNoteRequest noteRequest)
        {
            bool validation = GetValidationResult(noteRequest);

            if (!validation)
            {
                CreateNoteResponse createNotesResponse = new CreateNoteResponse()
                {
                    ResultCode = "ERROR",
                    Message = "Invalid request"

                };
                return StatusCode(StatusCodes.Status400BadRequest, createNotesResponse);
            }

            Note noteRequest_DB = _createNoteRequestMapper.CreateNoteRequestMap(noteRequest);

            // call to DB passing noteRequest_DB --> 
            //later the response will come from the DB
            //we will need a mapper here as well to set the DB info as CreateNotesResponse
            //for now, a dummy response
            //aa

            CreateNoteResponse response = new CreateNoteResponse()
            {

            };

            return new CreatedResult(string.Empty, response);
        }

        private bool GetValidationResult(CreateNoteRequest noteRequest)
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
