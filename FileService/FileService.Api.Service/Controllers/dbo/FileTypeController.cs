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
			ApplicationContext context,
			IFileTypeRepository fileTypeRepository,
			IFileTypeModelValidator fileTypeModelValidator
			) : base(logger,
			         context,
			         fileTypeRepository,
			         fileTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d812f805b3c73925fe198570ed97c64e</Hash>
</Codenesium>*/