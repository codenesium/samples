using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALEmailAddressMapper : DALAbstractEmailAddressMapper, IDALEmailAddressMapper
	{
		public DALEmailAddressMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>adc7e3068841b146e8d09763f6b6a8cd</Hash>
</Codenesium>*/