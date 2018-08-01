using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>116c8aa1cf60ed3e268cd01d8c79c4fd</Hash>
</Codenesium>*/