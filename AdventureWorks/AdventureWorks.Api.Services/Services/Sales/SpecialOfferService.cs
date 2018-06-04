using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class SpecialOfferService: AbstractSpecialOfferService, ISpecialOfferService
	{
		public SpecialOfferService(
			ILogger<SpecialOfferRepository> logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper BOLspecialOfferMapper,
			IDALSpecialOfferMapper DALspecialOfferMapper)
			: base(logger, specialOfferRepository,
			       specialOfferModelValidator,
			       BOLspecialOfferMapper,
			       DALspecialOfferMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>acb44674efdbc2f2d9048815018cd84c</Hash>
</Codenesium>*/