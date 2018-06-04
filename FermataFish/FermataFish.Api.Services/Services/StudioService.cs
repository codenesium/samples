using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class StudioService: AbstractStudioService, IStudioService
	{
		public StudioService(
			ILogger<StudioRepository> logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper BOLstudioMapper,
			IDALStudioMapper DALstudioMapper)
			: base(logger, studioRepository,
			       studioModelValidator,
			       BOLstudioMapper,
			       DALstudioMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>542fe3008852bbe7c7ecbe86a1d62051</Hash>
</Codenesium>*/