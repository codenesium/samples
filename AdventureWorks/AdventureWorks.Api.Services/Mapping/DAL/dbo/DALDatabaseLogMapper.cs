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
    <Hash>da41dc466c6b00824a0ded9c18c3c163</Hash>
</Codenesium>*/