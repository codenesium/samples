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
	public partial class BusinessEntityAddressRepository : AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
	{
		public BusinessEntityAddressRepository(
			ILogger<BusinessEntityAddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>82cadceb0cee534b82ed051612ae7fdb</Hash>
</Codenesium>*/