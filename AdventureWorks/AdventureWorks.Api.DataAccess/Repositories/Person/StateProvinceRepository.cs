using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class StateProvinceRepository : AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(
			ILogger<StateProvinceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>afe724fba7879e8833a3d486ed0ccd5c</Hash>
</Codenesium>*/