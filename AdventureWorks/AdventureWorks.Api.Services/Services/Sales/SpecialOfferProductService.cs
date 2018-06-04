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
	public class SpecialOfferProductService: AbstractSpecialOfferProductService, ISpecialOfferProductService
	{
		public SpecialOfferProductService(
			ILogger<SpecialOfferProductRepository> logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper BOLspecialOfferProductMapper,
			IDALSpecialOfferProductMapper DALspecialOfferProductMapper)
			: base(logger, specialOfferProductRepository,
			       specialOfferProductModelValidator,
			       BOLspecialOfferProductMapper,
			       DALspecialOfferProductMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8fb2d9a2098ff8821ca6d33fd1bba55c</Hash>
</Codenesium>*/