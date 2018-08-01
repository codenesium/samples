using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class VendorRepository : AbstractVendorRepository, IVendorRepository
	{
		public VendorRepository(
			ILogger<VendorRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d08bc4b887417fc056d9d4df7bd49c0d</Hash>
</Codenesium>*/