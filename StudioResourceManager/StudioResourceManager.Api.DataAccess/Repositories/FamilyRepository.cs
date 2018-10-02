using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
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
    <Hash>cca5a066b0bd88c9aea8492f51301e0b</Hash>
</Codenesium>*/