using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CultureService: AbstractCultureService, ICultureService
	{
		public CultureService(
			ILogger<CultureRepository> logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper BOLcultureMapper,
			IDALCultureMapper DALcultureMapper)
			: base(logger, cultureRepository,
			       cultureModelValidator,
			       BOLcultureMapper,
			       DALcultureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>93a02b59662c9a9c235b6bd128a1f049</Hash>
</Codenesium>*/