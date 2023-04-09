using Microsoft.AspNetCore.Mvc;
using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Requests;
using NotesAPI.Models.Responses;
using NotesAPI.Repositories;
using NotesAPI.Services;
using NotesAPI.Services.Mappers;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    public class NotesController: ControllerBase
    {
        private readonly IServiceProviderHandler _serviceProviderHandler;
        private readonly ICreateNoteRequestMapper _createNoteRequestMapper;
        private readonly IGetNoteResponseMapper _getNoteResponseMapper;
        private readonly ICreateNoteResponseMapper _createNoteResponseMapper;
        private readonly IUpdateNoteRequestMapper _updateNoteRequestMapper;
        private readonly IUpdateNoteResponseMapper _updateNoteResponseMapper;
        private readonly INoteService _noteService;


        public NotesController(IServiceProviderHandler serviceProviderHandler, ICreateNoteRequestMapper createNoteRequestMapper, ICreateNoteResponseMapper createNoteResponseMapper) 
        { 
            _serviceProviderHandler = serviceProviderHandler;
            _createNoteRequestMapper = _serviceProviderHandler.GetRequiredService<ICreateNoteRequestMapper>();
            _getNoteResponseMapper = _serviceProviderHandler.GetRequiredService<IGetNoteResponseMapper>();
            _createNoteResponseMapper = _serviceProviderHandler.GetRequiredService<ICreateNoteResponseMapper>();
            _updateNoteRequestMapper = _serviceProviderHandler.GetRequiredService<IUpdateNoteRequestMapper>();
            _updateNoteResponseMapper = _serviceProviderHandler.GetRequiredService<IUpdateNoteResponseMapper>();
            _noteService = _serviceProviderHandler.GetRequiredService<INoteService>();
        }


        [HttpPost]
        [Route("notes/createNote")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateNoteRequest createNoteRequest)
        {
            //bool validation = GetValidationResult(createNoteRequest);

            //if (!validation)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest);
            //}

            Note createNoteRequest_DB = _createNoteRequestMapper.CreateNoteRequestMap(createNoteRequest);
            Note createNoteResponse_DB = await _noteService.AddNote(createNoteRequest_DB);
            CreateNoteResponse createNoteResponse = _createNoteResponseMapper.CreateNoteResponseMap(createNoteResponse_DB);

            return new CreatedResult(string.Empty, createNoteResponse);
        }

        [HttpGet]
        [Route("notes/getNotesByTargetDate")]
        public IActionResult GetByTargetDate(DateTime targetDate)
        {
            List<Note> noteResponse_DB = _noteService.GetNotesByTargetDate(targetDate);
            List<GetNoteResponse> noteResponse = _getNoteResponseMapper.GetNoteResponseMap(noteResponse_DB);

            return new CreatedResult(string.Empty, noteResponse);
        }

        [HttpGet]
        [Route("notes/getNotesByCategory")]
        public IActionResult GetByCategory(Enums.Category category)
        {
            List<Note> noteResponse_DB = _noteService.GetNotesByCategory(category);
            List<GetNoteResponse> noteResponse = _getNoteResponseMapper.GetNoteResponseMap(noteResponse_DB);

            return new CreatedResult(string.Empty, noteResponse);

        }

        [HttpPut]
        [Route("notes/updateNoteTargetDate")]
        public async Task<IActionResult> UpdateNoteTargetDate(int noteId, DateTime targetDate)
        {

            Note updateNoteResponse_DB = await _noteService.UpdateNote(noteId, targetDate);
            UpdateNoteResponse updateNoteResponse = _updateNoteResponseMapper.UpdateNoteResponseMap(updateNoteResponse_DB);

            return new CreatedResult(string.Empty, updateNoteResponse);

        }

        [HttpPut]
        [Route("notes/deleteNote")]
        public string DeleteNote(int noteId)
        {
            _noteService.DeleteNote(noteId);
            return $"Note {noteId} was deleted successfully";
        }

        private bool GetValidationResult(CreateNoteRequest noteRequest)
        {
            bool isValid = true;

            Enums.Category category = noteRequest.Category; 
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
