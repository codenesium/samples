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
	[ServiceFilter(typeof(FileFilter))]
	public class FileController: AbstractFileController
	{
		public FileController(
			ILogger<FileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileRepository fileRepository
			)
			: base(logger,
			       transactionCoordinator,
			       fileRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>13ad0d1a4c2cfd660110069c2bced813</Hash>
</Codenesium>*/