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
	public class BOCulture: AbstractBOCulture, IBOCulture
	{
		public BOCulture(
			ILogger<CultureRepository> logger,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator)
			: base(logger, cultureRepository, cultureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2bf12229dcc7abb9f316a455b0258cf5</Hash>
</Codenesium>*/