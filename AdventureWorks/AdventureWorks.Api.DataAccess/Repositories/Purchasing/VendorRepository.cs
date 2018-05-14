using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class VendorRepository: AbstractVendorRepository, IVendorRepository
	{
		public VendorRepository(
			IObjectMapper mapper,
			ILogger<VendorRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ce54b28677d28501cabb1258a0fb510b</Hash>
</Codenesium>*/