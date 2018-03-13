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
	public class FilesController: FilesControllerAbstract
	{
		public FilesController(
			ILogger<FilesController> logger,
			ApplicationContext context,
			FileRepository fileRepository,
			FileModelValidator fileModelValidator
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
    <Hash>fe0b408ffdb4b639f8a7b52e03251212</Hash>
</Codenesium>*/