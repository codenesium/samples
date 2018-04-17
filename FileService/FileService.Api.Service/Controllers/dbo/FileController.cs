using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.BusinessObjects;

namespace FileServiceNS.Api.Service
{
	[Route("api/files")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class FileController: AbstractFileController
	{
		public FileController(
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFile fileManager
			)
			: base(logger,
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
    <Hash>293279a9154fc1124c8c3ad9aabc9f90</Hash>
</Codenesium>*/