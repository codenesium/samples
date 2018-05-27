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
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper specialOfferProductMapper)
			: base(logger, specialOfferProductRepository, specialOfferProductModelValidator, specialOfferProductMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>60fbe5ffecc9bd91c412941f560a2f2b</Hash>
</Codenesium>*/