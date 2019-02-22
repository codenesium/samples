using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class NoteRepository : AbstractNoteRepository, INoteRepository
	{
		public NoteRepository(
			ILogger<NoteRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d8070df06b31f8b4124f8a6ae3ab5f07</Hash>
</Codenesium>*/