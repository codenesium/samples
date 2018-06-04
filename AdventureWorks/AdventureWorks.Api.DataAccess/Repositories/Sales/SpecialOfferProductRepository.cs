using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SpecialOfferProductRepository: AbstractSpecialOfferProductRepository, ISpecialOfferProductRepository
	{
		public SpecialOfferProductRepository(
			ILogger<SpecialOfferProductRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ac10b23f9fd06f469e7cd54029021572</Hash>
</Codenesium>*/