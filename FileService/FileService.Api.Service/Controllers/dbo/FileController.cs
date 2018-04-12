using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	[Route("api/files")]
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
    <Hash>d00c938382b6df4a7356d25185312e9c</Hash>
</Codenesium>*/