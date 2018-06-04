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
	public class VendorService: AbstractVendorService, IVendorService
	{
		public VendorService(
			ILogger<VendorRepository> logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper BOLvendorMapper,
			IDALVendorMapper DALvendorMapper)
			: base(logger, vendorRepository,
			       vendorModelValidator,
			       BOLvendorMapper,
			       DALvendorMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>cd40b295c00f86119a4796a10bf2369e</Hash>
</Codenesium>*/