using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALEmployeePayHistoryMapper : DALAbstractEmployeePayHistoryMapper, IDALEmployeePayHistoryMapper
	{
		public DALEmployeePayHistoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>637a46e3e84db5933b9609a3d1cd99e7</Hash>
</Codenesium>*/