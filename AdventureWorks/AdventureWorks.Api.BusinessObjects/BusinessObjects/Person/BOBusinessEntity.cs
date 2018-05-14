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
			IApiBusinessEntityModelValidator businessEntityModelValidator)
			: base(logger, businessEntityRepository, businessEntityModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7acae479a23eb1203eb243acf3e178df</Hash>
</Codenesium>*/