using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOSpecialOffer: AbstractBOSpecialOffer, IBOSpecialOffer
	{
		public BOSpecialOffer(
			ILogger<SpecialOfferRepository> logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper specialOfferMapper)
			: base(logger, specialOfferRepository, specialOfferModelValidator, specialOfferMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2cf24ab60753118d8699d717c58eafac</Hash>
</Codenesium>*/