using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class NoteService : AbstractNoteService, INoteService
	{
		public NoteService(
			ILogger<INoteRepository> logger,
			IMediator mediator,
			INoteRepository noteRepository,
			IApiNoteServerRequestModelValidator noteModelValidator,
			IDALNoteMapper dalNoteMapper)
			: base(logger,
			       mediator,
			       noteRepository,
			       noteModelValidator,
			       dalNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f52025b284e82b46edbda3dd7ab34324</Hash>
</Codenesium>*/