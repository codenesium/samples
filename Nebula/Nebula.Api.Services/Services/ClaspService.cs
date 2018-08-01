using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ClaspService : AbstractClaspService, IClaspService
	{
		public ClaspService(
			ILogger<IClaspRepository> logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolclaspMapper,
			IDALClaspMapper dalclaspMapper
			)
			: base(logger,
			       claspRepository,
			       claspModelValidator,
			       bolclaspMapper,
			       dalclaspMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b23c7b131e0bb3a06b7e875ca606c40d</Hash>
</Codenesium>*/