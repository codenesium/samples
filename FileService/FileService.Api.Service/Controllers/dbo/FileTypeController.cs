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
	[Route("api/fileTypes")]
	public class FileTypeController: AbstractFileTypeController
	{
		public FileTypeController(
			ILogger<FileTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeRepository fileTypeRepository,
			IFileTypeModelValidator fileTypeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       fileTypeRepository,
			       fileTypeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>66e2fc28177e7dbb3ebb94d1c42e4c15</Hash>
</Codenesium>*/