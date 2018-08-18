using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>5dbb5daefd8f532f5d78e44e836163c8</Hash>
</Codenesium>*/