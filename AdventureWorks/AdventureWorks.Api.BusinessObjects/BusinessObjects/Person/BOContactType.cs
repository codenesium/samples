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
	public class BOContactType: AbstractBOContactType, IBOContactType
	{
		public BOContactType(
			ILogger<ContactTypeRepository> logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeModelValidator contactTypeModelValidator)
			: base(logger, contactTypeRepository, contactTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e21b184263ab964f14d051cc121c9b3e</Hash>
</Codenesium>*/