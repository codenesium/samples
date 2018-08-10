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
    <Hash>9b73463bc2135b02b4cfe957f123d705</Hash>
</Codenesium>*/