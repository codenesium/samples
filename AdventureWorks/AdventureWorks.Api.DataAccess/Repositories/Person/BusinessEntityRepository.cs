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
    <Hash>0c1376a1e0db8f82dc5691a19b55d8a1</Hash>
</Codenesium>*/