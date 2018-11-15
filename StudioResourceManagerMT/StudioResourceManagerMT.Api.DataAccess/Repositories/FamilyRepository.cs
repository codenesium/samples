using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class FamilyRepository : AbstractFamilyRepository, IFamilyRepository
	{
		public FamilyRepository(
			ILogger<FamilyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ee3c78d90b6698764bca913b8f696704</Hash>
</Codenesium>*/