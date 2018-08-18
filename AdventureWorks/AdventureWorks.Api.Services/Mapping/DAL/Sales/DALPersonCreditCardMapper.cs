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
    <Hash>feeb2f464c608b375cce445740781065</Hash>
</Codenesium>*/