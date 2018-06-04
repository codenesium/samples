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
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Web
{
	[Route("api/fileTypes")]
	[ApiVersion("1.0")]
	public class FileTypeController: AbstractFileTypeController
	{
		public FileTypeController(
			ServiceSettings settings,
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeService fileTypeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileTypeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>145dfe6d946e4da04674fa81caca873a</Hash>
</Codenesium>*/