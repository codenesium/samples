using System;
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
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator
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
    <Hash>754a24a58f8ee3b706d95f38c16ab9e8</Hash>
</Codenesium>*/