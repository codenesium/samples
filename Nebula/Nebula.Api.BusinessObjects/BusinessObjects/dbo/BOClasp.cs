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
			IClaspModelValidator claspModelValidator)
			: base(logger, claspRepository, claspModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5768317b8b72111742b256ad03b19205</Hash>
</Codenesium>*/