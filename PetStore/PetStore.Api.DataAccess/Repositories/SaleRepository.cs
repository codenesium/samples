using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial class SaleRepository : AbstractSaleRepository, ISaleRepository
	{
		public SaleRepository(
			ILogger<SaleRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>87db8cee8e28ca214cd8d1a3bd261f4d</Hash>
</Codenesium>*/