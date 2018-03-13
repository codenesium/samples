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
			FileTypeRepository fileTypeRepository,
			FileTypeModelValidator fileTypeModelValidator
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
    <Hash>3d5faaef44bda76de006efc84fcadde8</Hash>
</Codenesium>*/