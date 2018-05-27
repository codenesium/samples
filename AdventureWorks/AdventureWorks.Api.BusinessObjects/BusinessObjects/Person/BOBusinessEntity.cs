using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOBusinessEntity: AbstractBOBusinessEntity, IBOBusinessEntity
	{
		public BOBusinessEntity(
			ILogger<BusinessEntityRepository> logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper businessEntityMapper)
			: base(logger, businessEntityRepository, businessEntityModelValidator, businessEntityMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>d902e08d66c10b8114cdcda3a225c515</Hash>
</Codenesium>*/