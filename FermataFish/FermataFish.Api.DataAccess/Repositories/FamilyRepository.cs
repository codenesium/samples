using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>a8845a07f58d810770a8c13ee8db9a50</Hash>
</Codenesium>*/