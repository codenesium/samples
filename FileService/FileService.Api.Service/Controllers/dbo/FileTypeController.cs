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
	[Route("api/fileTypes")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class FileTypeController: AbstractFileTypeController
	{
		public FileTypeController(
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFileType fileTypeManager
			)
			: base(logger,
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
    <Hash>fb904073214743df8dad852a560a88a9</Hash>
</Codenesium>*/