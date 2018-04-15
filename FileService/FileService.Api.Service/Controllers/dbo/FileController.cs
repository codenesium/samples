using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	[Route("api/files")]
	[ApiVersion("1.0")]
	public class FileController: AbstractFileController
	{
		public FileController(
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileRepository fileRepository,
			IFileModelValidator fileModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       fileRepository,
			       fileModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9e1555ae181359c0b92a36e9825dbbf6</Hash>
</Codenesium>*/