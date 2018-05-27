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
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper contactTypeMapper)
			: base(logger, contactTypeRepository, contactTypeModelValidator, contactTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7fcec8a5eb88e89380d066f2d75b157b</Hash>
</Codenesium>*/