using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class BillOfMaterialsRepository: AbstractBillOfMaterialsRepository, IBillOfMaterialsRepository
	{
		public BillOfMaterialsRepository(
			ILogger<BillOfMaterialsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c4cd62b27da0978f7ae1b26f3504d564</Hash>
</Codenesium>*/