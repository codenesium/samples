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
	public class FileTypesController: FileTypesControllerAbstract
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
    <Hash>3d7bb85846fb0e016b1df1066df02ac3</Hash>
</Codenesium>*/