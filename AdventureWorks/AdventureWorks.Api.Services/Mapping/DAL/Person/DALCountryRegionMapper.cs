using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCountryRegionMapper : DALAbstractCountryRegionMapper, IDALCountryRegionMapper
	{
		public DALCountryRegionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>481c0b40e3f0b385d8f4497110e3a258</Hash>
</Codenesium>*/