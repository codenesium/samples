using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class BusinessEntityContactService: AbstractBusinessEntityContactService, IBusinessEntityContactService
	{
		public BusinessEntityContactService(
			ILogger<BusinessEntityContactRepository> logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper BOLbusinessEntityContactMapper,
			IDALBusinessEntityContactMapper DALbusinessEntityContactMapper)
			: base(logger, businessEntityContactRepository,
			       businessEntityContactModelValidator,
			       BOLbusinessEntityContactMapper,
			       DALbusinessEntityContactMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>d532d6cb48653aeb3de7eb6251607e50</Hash>
</Codenesium>*/