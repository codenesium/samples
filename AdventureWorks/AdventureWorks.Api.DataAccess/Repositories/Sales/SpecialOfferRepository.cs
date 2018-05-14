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
			IObjectMapper mapper,
			ILogger<SpecialOfferRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b615ff107528456d61f063685a4153bc</Hash>
</Codenesium>*/