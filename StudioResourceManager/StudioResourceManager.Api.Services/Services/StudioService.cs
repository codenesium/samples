using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class StudioService : AbstractStudioService, IStudioService
	{
		public StudioService(
			ILogger<IStudioRepository> logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolstudioMapper,
			IDALStudioMapper dalstudioMapper)
			: base(logger,
			       studioRepository,
			       studioModelValidator,
			       bolstudioMapper,
			       dalstudioMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8bc663c1fcae43494b416f28e20d9bf6</Hash>
</Codenesium>*/