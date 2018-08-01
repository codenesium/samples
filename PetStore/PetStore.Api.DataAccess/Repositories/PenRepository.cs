using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
	public partial class PenRepository : AbstractPenRepository, IPenRepository
	{
		public PenRepository(
			ILogger<PenRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f84e3dbb24f6447fb053862c5aa2e5ed</Hash>
</Codenesium>*/