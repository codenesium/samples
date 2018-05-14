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
	public class BillOfMaterialsRepository: AbstractBillOfMaterialsRepository, IBillOfMaterialsRepository
	{
		public BillOfMaterialsRepository(
			IObjectMapper mapper,
			ILogger<BillOfMaterialsRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>811dfb174b3c843810022001dfc3b965</Hash>
</Codenesium>*/