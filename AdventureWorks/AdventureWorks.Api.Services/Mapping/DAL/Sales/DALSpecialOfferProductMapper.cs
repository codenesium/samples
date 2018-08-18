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
    <Hash>caa1a509e2a3f682f89fce2ff2f38c65</Hash>
</Codenesium>*/