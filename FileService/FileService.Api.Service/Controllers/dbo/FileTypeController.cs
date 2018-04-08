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
	public class FileTypesController: AbstractFileTypesController
	{
		public FileTypesController(
			ILogger<FileTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileTypeRepository fileTypeRepository,
			IFileTypeModelValidator fileTypeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         fileTypeRepository,
			         fileTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>055138f51a1070227f0e1d5cc8c2f736</Hash>
</Codenesium>*/