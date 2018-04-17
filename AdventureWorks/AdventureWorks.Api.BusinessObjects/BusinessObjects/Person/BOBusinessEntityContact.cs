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
			IBusinessEntityContactModelValidator businessEntityContactModelValidator)
			: base(logger, businessEntityContactRepository, businessEntityContactModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>12e725d21d2217f2da551411cc725204</Hash>
</Codenesium>*/