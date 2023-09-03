using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            var handler = new UpdateNoteCommandHandler(Context);
            var updateTitle = "update title";
            var updateDetails = "update details";

            await handler.Handle(
                new UpdateNoteCommand
                {
                    NoteId = NotesContextFactory.NoteIdForUpdate,
                    UserId = NotesContextFactory.UserBId,
                    Title = updateTitle,
                    Details = updateDetails
                },
                CancellationToken.None);

            Assert.NotNull(
                await Context.notes.SingleOrDefaultAsync(note =>
                note.NoteId == NotesContextFactory.NoteIdForUpdate && note.Title == updateTitle
                && note.Details == updateDetails));

        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateNoteCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        NoteId = Guid.NewGuid(),
                        UserId = NotesContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            var handler = new UpdateNoteCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        NoteId = NotesContextFactory.NoteIdForUpdate,
                        UserId = NotesContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
    }
}
