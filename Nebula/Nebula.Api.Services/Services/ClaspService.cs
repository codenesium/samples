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
    <Hash>a78afcfd9d790f0b51e1a514df9adce3</Hash>
</Codenesium>*/