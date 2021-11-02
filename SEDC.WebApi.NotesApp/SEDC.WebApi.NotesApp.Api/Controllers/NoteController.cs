using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NotesApp.Models;
using SEDC.WebApi.NotesApp.Services.Exceptions;
using SEDC.WebApi.NotesApp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SEDC.WebApi.NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            this._noteService = noteService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] NoteDto request)
        {
            try
            {
                _noteService.AddNote(request);
                // TODO: return create response
                return Ok("Success");
            }
            catch (NoteException ex)
            {
                Debug.WriteLine($"NOTE: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"NOTE: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteDto>> Get([FromQuery] int id)
        {
            try
            {
                return Ok(_noteService.GetUserNotes(id));
            }
            catch (NoteException ex)
            {
               
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<NoteDto> Get( int id, [FromQuery] int userId)
        {
            try
            {
                return Ok(_noteService.GetNote(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromQuery] int userId)
        {
            try
            {
                _noteService.DeleteNote(id, userId);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
