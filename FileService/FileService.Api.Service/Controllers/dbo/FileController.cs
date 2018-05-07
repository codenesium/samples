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
    <Hash>86c58983a1a568e479ac18bd2d30f116</Hash>
</Codenesium>*/