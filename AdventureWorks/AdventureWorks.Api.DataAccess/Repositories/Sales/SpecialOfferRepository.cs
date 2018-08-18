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
	public partial class SpecialOfferRepository : AbstractSpecialOfferRepository, ISpecialOfferRepository
	{
		public SpecialOfferRepository(
			ILogger<SpecialOfferRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>817a2a7d8f61886d793ff4a7190513eb</Hash>
</Codenesium>*/