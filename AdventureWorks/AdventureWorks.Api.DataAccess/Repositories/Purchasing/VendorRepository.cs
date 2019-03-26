using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fccd5a30eb2ff9208cf16457ee6ca2e9</Hash>
</Codenesium>*/