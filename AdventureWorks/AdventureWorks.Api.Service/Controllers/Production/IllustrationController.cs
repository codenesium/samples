using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/illustrations")]
	public class IllustrationsController: AbstractIllustrationsController
	{
		public IllustrationsController(
			ILogger<IllustrationsController> logger,
			ApplicationContext context,
			IIllustrationRepository illustrationRepository,
			IIllustrationModelValidator illustrationModelValidator
			) : base(logger,
			         context,
			         illustrationRepository,
			         illustrationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3953f66802343eea341bbc9b71a4cbdd</Hash>
</Codenesium>*/