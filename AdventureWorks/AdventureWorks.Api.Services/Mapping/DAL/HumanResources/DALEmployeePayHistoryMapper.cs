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
    <Hash>df4ea125d180c9b7e54626bfc89ebd2b</Hash>
</Codenesium>*/