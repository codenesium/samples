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
			IDALBillOfMaterialsMapper mapper,
			ILogger<BillOfMaterialsRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f823233a5031d57958e6a56349ed331a</Hash>
</Codenesium>*/