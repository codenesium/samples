using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSpecialOfferProductMapper : DALAbstractSpecialOfferProductMapper, IDALSpecialOfferProductMapper
	{
		public DALSpecialOfferProductMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>452be095d50362f35eb76eabf7d7c2f9</Hash>
</Codenesium>*/