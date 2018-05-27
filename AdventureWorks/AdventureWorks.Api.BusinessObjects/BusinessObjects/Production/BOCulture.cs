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
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper cultureMapper)
			: base(logger, cultureRepository, cultureModelValidator, cultureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a54e7f2e4c4d05a085fc4365565d4082</Hash>
</Codenesium>*/