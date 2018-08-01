using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
	{
		public DALPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>04111a6e40e8b9881d0d02c6b6600485</Hash>
</Codenesium>*/