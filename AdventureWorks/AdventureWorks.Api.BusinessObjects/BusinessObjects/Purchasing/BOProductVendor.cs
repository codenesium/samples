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
	public class BOProductVendor: AbstractBOProductVendor, IBOProductVendor
	{
		public BOProductVendor(
			ILogger<ProductVendorRepository> logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorModelValidator productVendorModelValidator)
			: base(logger, productVendorRepository, productVendorModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>917bc43188e99c55197b507400d067de</Hash>
</Codenesium>*/