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
			ApplicationContext context,
			IFileRepository fileRepository,
			IFileModelValidator fileModelValidator
			) : base(logger,
			         context,
			         fileRepository,
			         fileModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9d3bd1d186d40e79f458fd07a3d5ae9a</Hash>
</Codenesium>*/