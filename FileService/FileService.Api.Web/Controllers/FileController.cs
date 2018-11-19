using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
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

namespace FileServiceNS.Api.Web
{
	[Route("api/files")]
	[ApiController]
	[ApiVersion("1.0")]

	public class FileController : AbstractFileController
	{
		public FileController(
			ApiSettings settings,
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileService fileService,
			IApiFileServerModelMapper fileModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileService,
			       fileModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e9819ba4cc4ab613cafe2b9d7a21a16d</Hash>
</Codenesium>*/