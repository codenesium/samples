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
	public class FilesController: AbstractFilesController
	{
		public FilesController(
			ILogger<FilesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileRepository fileRepository,
			IFileModelValidator fileModelValidator
			) : base(logger,
			         transactionCoordinator,
			         fileRepository,
			         fileModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>869d786597f253a5fd118219ed6f2737</Hash>
</Codenesium>*/