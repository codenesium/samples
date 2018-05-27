using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class SaleRepository: AbstractSaleRepository, ISaleRepository
	{
		public SaleRepository(
			IDALSaleMapper mapper,
			ILogger<SaleRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f91272941dce5e37ee9249f7caed25cf</Hash>
</Codenesium>*/