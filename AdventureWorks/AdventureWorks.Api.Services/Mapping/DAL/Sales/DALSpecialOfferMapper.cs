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
    <Hash>be1d4499ebf4c268e64772e0a430b64a</Hash>
</Codenesium>*/