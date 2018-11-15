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
	[Route("api/fileTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class FileTypeController : AbstractFileTypeController
	{
		public FileTypeController(
			ApiSettings settings,
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeService fileTypeService,
			IApiFileTypeServerModelMapper fileTypeModelMapper
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
    <Hash>f1275114d85544bdd30cfeb0fbef9b1f</Hash>
</Codenesium>*/