using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOStudio: AbstractBOStudio, IBOStudio
	{
		public BOStudio(
			ILogger<StudioRepository> logger,
			IStudioRepository studioRepository,
			IStudioModelValidator studioModelValidator)
			: base(logger, studioRepository, studioModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>1ddd719af3440bbcbb00008c74e1484a</Hash>
</Codenesium>*/