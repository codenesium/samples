using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSpecialOfferMapper : DALAbstractSpecialOfferMapper, IDALSpecialOfferMapper
	{
		public DALSpecialOfferMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>d7e3019a431f40f831b1a023c854e680</Hash>
</Codenesium>*/