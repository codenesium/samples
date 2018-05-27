using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SpecialOfferRepository: AbstractSpecialOfferRepository, ISpecialOfferRepository
	{
		public SpecialOfferRepository(
			IDALSpecialOfferMapper mapper,
			ILogger<SpecialOfferRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7face8c15f45db281a8eeea82b11f4d9</Hash>
</Codenesium>*/