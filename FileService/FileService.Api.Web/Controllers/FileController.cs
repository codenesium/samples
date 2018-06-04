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
	[Route("api/files")]
	[ApiVersion("1.0")]
	public class FileController: AbstractFileController
	{
		public FileController(
			ServiceSettings settings,
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileService fileService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e6cbf8082cc7a571d7817c0f03f623d3</Hash>
</Codenesium>*/