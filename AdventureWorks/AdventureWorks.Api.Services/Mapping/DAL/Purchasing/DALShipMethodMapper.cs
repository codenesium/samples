using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALShipMethodMapper : DALAbstractShipMethodMapper, IDALShipMethodMapper
	{
		public DALShipMethodMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c7fc34f4d438d9c465401cb533be6dc4</Hash>
</Codenesium>*/