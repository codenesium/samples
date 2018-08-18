using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductMapper : DALAbstractProductMapper, IDALProductMapper
	{
		public DALProductMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>61c3ea18c173dc3fd2af7679a496c978</Hash>
</Codenesium>*/