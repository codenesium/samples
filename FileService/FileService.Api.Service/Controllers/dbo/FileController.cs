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
	[Route("api/files")]
	[ApiVersion("1.0")]
	[Response]
	public class FileController: AbstractFileController
	{
		public FileController(
			ServiceSettings settings,
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFile fileManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       fileManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a0c39c64c8396b79998c62d296fb846e</Hash>
</Codenesium>*/