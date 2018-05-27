using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class ClaspRepository: AbstractClaspRepository, IClaspRepository
	{
		public ClaspRepository(
			IDALClaspMapper mapper,
			ILogger<ClaspRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>d28bcd856bf275faccdbe5a1960db0c3</Hash>
</Codenesium>*/