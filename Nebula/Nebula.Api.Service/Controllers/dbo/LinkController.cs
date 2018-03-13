using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[Route("api/links")]
	public class LinksController: LinksControllerAbstract
	{
		public LinksController(
			ILogger<LinksController> logger,
			ApplicationContext context,
			LinkRepository linkRepository,
			LinkModelValidator linkModelValidator
			) : base(logger,
			         context,
			         linkRepository,
			         linkModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0340def484b9e9088cec6ec49eee64f1</Hash>
</Codenesium>*/