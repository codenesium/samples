using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCreditCardMapper : DALAbstractCreditCardMapper, IDALCreditCardMapper
	{
		public DALCreditCardMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5985dce3d74302ca3a1ca2f04b7a4c1c</Hash>
</Codenesium>*/