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
    <Hash>2d763efed429103ec303a49e8d48efa1</Hash>
</Codenesium>*/