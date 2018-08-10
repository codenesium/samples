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
	public partial class BusinessEntityContactRepository : AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
	{
		public BusinessEntityContactRepository(
			ILogger<BusinessEntityContactRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a2f54e7ffcb6e05867827bd5c4a4dd69</Hash>
</Codenesium>*/