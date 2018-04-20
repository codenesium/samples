using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.BusinessObjects;

namespace FileServiceNS.Api.Service
{
	[Route("api/fileTypes")]
	[ApiVersion("1.0")]
	[Response]
	public class FileTypeController: AbstractFileTypeController
	{
		public FileTypeController(
			ServiceSettings settings,
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFileType fileTypeManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileTypeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f0f14b49e9cd92ce2ded692077fe89cd</Hash>
</Codenesium>*/