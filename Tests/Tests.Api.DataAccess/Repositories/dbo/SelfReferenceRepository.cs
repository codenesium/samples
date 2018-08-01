using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class SelfReferenceRepository : AbstractSelfReferenceRepository, ISelfReferenceRepository
	{
		public SelfReferenceRepository(
			ILogger<SelfReferenceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3d7375b9fd267c80ca173889018f28e6</Hash>
</Codenesium>*/