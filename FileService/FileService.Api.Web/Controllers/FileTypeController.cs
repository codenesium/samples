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
using System.Threading.Tasks;

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
    <Hash>ae6a3e24e1e7774b42edd6bd8ebbd57a</Hash>
</Codenesium>*/