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
			IProductVendorModelValidator productVendorModelValidator)
			: base(logger, productVendorRepository, productVendorModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9bd6f953bbb321e1ae11a7269ae67d55</Hash>
</Codenesium>*/