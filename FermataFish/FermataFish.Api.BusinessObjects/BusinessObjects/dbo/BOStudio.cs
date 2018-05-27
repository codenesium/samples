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
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper studioMapper)
			: base(logger, studioRepository, studioModelValidator, studioMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b1efc35e04d1346f9dbe755f24b2a342</Hash>
</Codenesium>*/