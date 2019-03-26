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
	public partial class BusinessEntityRepository : AbstractBusinessEntityRepository, IBusinessEntityRepository
	{
		public BusinessEntityRepository(
			ILogger<BusinessEntityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>751cc99e1af823e3ebd4c5503276c16e</Hash>
</Codenesium>*/