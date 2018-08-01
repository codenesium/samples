using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductModelMapper : DALAbstractProductModelMapper, IDALProductModelMapper
	{
		public DALProductModelMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e7e24ac29f224088f6ba237649c2fe63</Hash>
</Codenesium>*/