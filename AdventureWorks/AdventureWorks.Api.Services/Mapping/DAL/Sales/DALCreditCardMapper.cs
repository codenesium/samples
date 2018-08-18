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
    <Hash>77081951ab1c43b0d239395b4cb1877b</Hash>
</Codenesium>*/