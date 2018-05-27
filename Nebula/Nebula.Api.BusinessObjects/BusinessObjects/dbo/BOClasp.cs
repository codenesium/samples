using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOClasp: AbstractBOClasp, IBOClasp
	{
		public BOClasp(
			ILogger<ClaspRepository> logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper claspMapper)
			: base(logger, claspRepository, claspModelValidator, claspMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c2c4d45ef5bb7efaa69bb8435a83bd00</Hash>
</Codenesium>*/