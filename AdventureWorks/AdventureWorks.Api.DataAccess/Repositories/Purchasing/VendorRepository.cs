using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class VendorRepository: AbstractVendorRepository, IVendorRepository
	{
		public VendorRepository(
			ILogger<VendorRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a44c2039a1463005e9c510f3b3c1d3ea</Hash>
</Codenesium>*/