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
			IApiCultureModelValidator cultureModelValidator)
			: base(logger, cultureRepository, cultureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d1318cdbf69604107b700e41adee9b8f</Hash>
</Codenesium>*/