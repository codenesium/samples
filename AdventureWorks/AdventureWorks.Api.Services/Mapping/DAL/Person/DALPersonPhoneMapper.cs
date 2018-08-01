using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPersonPhoneMapper : DALAbstractPersonPhoneMapper, IDALPersonPhoneMapper
	{
		public DALPersonPhoneMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e8545b66c3482c939c768fc4e87baec</Hash>
</Codenesium>*/