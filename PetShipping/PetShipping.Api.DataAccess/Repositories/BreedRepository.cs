using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class BreedRepository : AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9066ee8a03b21ad48062dbcb4515f766</Hash>
</Codenesium>*/