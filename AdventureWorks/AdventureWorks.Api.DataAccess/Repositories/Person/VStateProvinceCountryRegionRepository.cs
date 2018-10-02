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
	public partial class VStateProvinceCountryRegionRepository : AbstractVStateProvinceCountryRegionRepository, IVStateProvinceCountryRegionRepository
	{
		public VStateProvinceCountryRegionRepository(
			ILogger<VStateProvinceCountryRegionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ea1191d6c48b8260cb98e86e9393f90</Hash>
</Codenesium>*/