using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALShiftMapper : DALAbstractShiftMapper, IDALShiftMapper
	{
		public DALShiftMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5a93e3ce23873b1a9ec21219d7ac9386</Hash>
</Codenesium>*/