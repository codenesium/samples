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
	public partial class BillOfMaterialRepository : AbstractBillOfMaterialRepository, IBillOfMaterialRepository
	{
		public BillOfMaterialRepository(
			ILogger<BillOfMaterialRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>20054a9a116c690b5d11c533342632f6</Hash>
</Codenesium>*/