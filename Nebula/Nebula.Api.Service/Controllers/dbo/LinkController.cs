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
	public class LinksController: AbstractLinksController
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
    <Hash>f7d715c7e27b6039cb437e8486611ce4</Hash>
</Codenesium>*/