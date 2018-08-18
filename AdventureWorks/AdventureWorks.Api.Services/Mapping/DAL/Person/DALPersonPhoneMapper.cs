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
    <Hash>33dfe9076ac87f37626adff668384285</Hash>
</Codenesium>*/