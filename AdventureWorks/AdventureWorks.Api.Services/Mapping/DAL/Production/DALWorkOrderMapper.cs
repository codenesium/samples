using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALWorkOrderMapper : DALAbstractWorkOrderMapper, IDALWorkOrderMapper
	{
		public DALWorkOrderMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e5a492f702babb71a7e839a21bf2e23a</Hash>
</Codenesium>*/