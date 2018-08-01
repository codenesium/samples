using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class StudioRepository : AbstractStudioRepository, IStudioRepository
	{
		public StudioRepository(
			ILogger<StudioRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ebbd0c2b9f52ccaabb52b7b1c506c68b</Hash>
</Codenesium>*/