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
			ISpecialOfferProductModelValidator specialOfferProductModelValidator)
			: base(logger, specialOfferProductRepository, specialOfferProductModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6b55456e4e4176518d7d351709a5d52d</Hash>
</Codenesium>*/