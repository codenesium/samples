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
			ISpecialOfferModelValidator specialOfferModelValidator)
			: base(logger, specialOfferRepository, specialOfferModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f87b30002568e149d818f9456c96dea1</Hash>
</Codenesium>*/