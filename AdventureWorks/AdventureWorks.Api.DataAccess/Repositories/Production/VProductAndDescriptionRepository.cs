using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class VProductAndDescriptionRepository : AbstractVProductAndDescriptionRepository, IVProductAndDescriptionRepository
	{
		public VProductAndDescriptionRepository(
			ILogger<VProductAndDescriptionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>620a1499dd98e7c430f2c7f76d49c7d4</Hash>
</Codenesium>*/