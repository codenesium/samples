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
	public class BOBusinessEntityContact: AbstractBOBusinessEntityContact, IBOBusinessEntityContact
	{
		public BOBusinessEntityContact(
			ILogger<BusinessEntityContactRepository> logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactModelValidator businessEntityContactModelValidator)
			: base(logger, businessEntityContactRepository, businessEntityContactModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f852216a6f56b6d73c1c0df4f6cb7490</Hash>
</Codenesium>*/