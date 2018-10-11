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
	public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<ISpaceFeatureRepository> logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolspaceFeatureMapper,
			IDALSpaceFeatureMapper dalspaceFeatureMapper,
			IBOLSpaceSpaceFeatureMapper bolSpaceSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       bolspaceFeatureMapper,
			       dalspaceFeatureMapper,
			       bolSpaceSpaceFeatureMapper,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>66169ed7ea19fca0c90bcdea38eb1a3c</Hash>
</Codenesium>*/