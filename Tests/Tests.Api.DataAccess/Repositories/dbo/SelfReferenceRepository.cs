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
    <Hash>0ed16fdb0c2ece6159890bc86957aaf0</Hash>
</Codenesium>*/