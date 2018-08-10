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
    <Hash>125ff93bfbf60fbe8fa7e2b7aaf486ab</Hash>
</Codenesium>*/