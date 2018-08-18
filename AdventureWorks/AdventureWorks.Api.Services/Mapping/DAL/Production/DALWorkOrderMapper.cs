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
    <Hash>5f36544c2cab1115d8fdcf070ed5f781</Hash>
</Codenesium>*/