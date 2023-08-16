using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Sections.Commands.CreateSection;
using Notes.Application.Sections.Commands.DeleteSection;
using Notes.Application.Sections.Commands.UpdateSection;
using Notes.Application.Sections.Queries.GetSectionDetails;
using Notes.Domain;
using Notes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SectionController : BaseController
    {
        private readonly IMapper _mapper;
        public SectionController(IMapper mapper) =>
            (_mapper) = (mapper);

        /// <summary>
        /// Gets all the sections
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet("{roomId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SectionListVm>> GetAll(Guid roomId)
        {
            var query = new GetSectionListQuery { RoomId = roomId };

            var vm = await Mediator.Send(query);
            return vm;
        }



        /// <summary>
        /// Create the section
        /// </summary>
        /// <param name="createSectionDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CreateSectionDto createSectionDto)
        {
            var command = _mapper.Map<CreateSectionCommand>(createSectionDto);

            var section = await Mediator.Send(command);
            return Ok(section);
        }

        /// <summary>
        /// Update the section
        /// </summary>
        /// <param name="updateSectionDto"></param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Section>> Update([FromBody] UpdateSectionDto updateSectionDto)
        {
            var command = _mapper.Map<UpdateSectionCommand>(updateSectionDto);
            command.UserId = UserId;

            var section = await Mediator.Send(command);

            return Ok(section);
        }

        /// <summary>
        /// Delete the section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteSectionCommand
            {
                SectionId = id,
                UserId = UserId
            };

            var sectionId = await Mediator.Send(command);
            return Ok(sectionId);
        }
    }
}