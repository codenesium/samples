using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Web
{
	[Route("api/fileTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class FileTypeController : AbstractFileTypeController
	{
		public FileTypeController(
			ApiSettings settings,
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeService fileTypeService,
			IApiFileTypeModelMapper fileTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileTypeService,
			       fileTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>097eb03fab8dd719ba0af9b391e6a09b</Hash>
</Codenesium>*/