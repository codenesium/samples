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
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper businessEntityContactMapper)
			: base(logger, businessEntityContactRepository, businessEntityContactModelValidator, businessEntityContactMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>24a743e8d983a6490db1eb77e595998b</Hash>
</Codenesium>*/