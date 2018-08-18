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
    <Hash>b05d58b91f56cdb3aa4f55170ac712f8</Hash>
</Codenesium>*/