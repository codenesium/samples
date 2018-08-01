using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALDatabaseLogMapper : DALAbstractDatabaseLogMapper, IDALDatabaseLogMapper
	{
		public DALDatabaseLogMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>432842220966838347fa88eda6734f1d</Hash>
</Codenesium>*/