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
	public class BOSpecialOfferProduct: AbstractBOSpecialOfferProduct, IBOSpecialOfferProduct
	{
		public BOSpecialOfferProduct(
			ILogger<SpecialOfferProductRepository> logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductModelValidator specialOfferProductModelValidator)
			: base(logger, specialOfferProductRepository, specialOfferProductModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>aead8391bc774bd71d1fce35be602f12</Hash>
</Codenesium>*/