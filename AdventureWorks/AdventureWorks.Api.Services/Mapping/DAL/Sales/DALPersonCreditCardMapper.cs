using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPersonCreditCardMapper : DALAbstractPersonCreditCardMapper, IDALPersonCreditCardMapper
	{
		public DALPersonCreditCardMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>62f997f3a1fba6902992b7d66062be8c</Hash>
</Codenesium>*/