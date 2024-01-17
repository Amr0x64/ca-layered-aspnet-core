using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INotesDbContext _db;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        
        public GetNoteListQueryHandler(INotesDbContext db, IMapper mapper, ICacheService cache)
        {
            _db = db;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
            {
            List<NoteLookupDto> notesQuery = await _cache.GetCachedValueAsync<List<NoteLookupDto>>(request.UserId.ToString());

            if (notesQuery is null)
            {
                notesQuery = await _db.notes.Where(note => note.UserId.ToString().ToLower() == request.UserId.ToString().ToLower())
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    
                await _cache.SetCachedValueAsync(request.UserId.ToString(), notesQuery, TimeSpan.FromSeconds(40));
            }
    
            return new NoteListVm { Notes = notesQuery };
        }
    }
}
