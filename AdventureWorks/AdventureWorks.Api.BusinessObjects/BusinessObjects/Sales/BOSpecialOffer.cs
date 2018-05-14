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
			IApiSpecialOfferModelValidator specialOfferModelValidator)
			: base(logger, specialOfferRepository, specialOfferModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b9f16ad80bb7f75f6ec41e70dc9edc36</Hash>
</Codenesium>*/