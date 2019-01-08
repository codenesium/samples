using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>f6b43dab04671503bde8bb7ed8fce6b6</Hash>
</Codenesium>*/