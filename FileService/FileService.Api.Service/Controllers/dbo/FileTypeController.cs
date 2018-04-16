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
	[Route("api/fileTypes")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(FileTypeFilter))]
	public class FileTypeController: AbstractFileTypeController
	{
		public FileTypeController(
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeRepository fileTypeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       fileTypeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7ed782a8ce9d3ce03f0ad01ff7c620f1</Hash>
</Codenesium>*/