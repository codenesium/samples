using CADNS.Api.Contracts;
using CADNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CADNS.Api.Web
{
	[Route("api/notes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class NoteController : AbstractNoteController
	{
		public NoteController(
			ApiSettings settings,
			ILogger<NoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			INoteService noteService,
			IApiNoteServerModelMapper noteModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       noteService,
			       noteModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a62da4370bec73a4f9ca1cd778aeb977</Hash>
</Codenesium>*/