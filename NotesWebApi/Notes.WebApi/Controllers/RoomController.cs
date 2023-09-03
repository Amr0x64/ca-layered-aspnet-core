using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Notes.Application.Rooms.Commands.CreateRoom;
using Notes.Application.Rooms.Commands.DeleteRoom;
using Notes.Application.Rooms.Commands.UpdateRoom;
using Notes.Application.Rooms.Queries.GetRoomList;
using Notes.WebApi.Models;

namespace Notes.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class RoomController : BaseController
    {
        private readonly IMapper _mapper;
        public RoomController(IMapper mapper) =>
            (_mapper) = (mapper);

        /// <summary>
        /// Gets the list of node
        /// </summary>
        /// <remarks>
        /// Sample requests
        /// GET /note
        /// </remarks>
        /// <returns>Returns RoomListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RoomListVm>> GetAll()
        {
            var query = new GetRoomListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Create the room
        /// </summary>
        /// <param name="createRoomDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoomDto createRoomDto)
        {
            var command = _mapper.Map<CreateRoomCommand>(createRoomDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);

            return noteId; 
        }

        /// <summary>
        /// Update the room
        /// </summary>
        /// <param name="updateRoomDto"></param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateRoomDto updateRoomDto)
        {
            var command = _mapper.Map<UpdateRoomCommand>(updateRoomDto);
            command.UserId = UserId;

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete the room
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteRoomCommand
            {
                RoomId = id,
                UserId = UserId
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
