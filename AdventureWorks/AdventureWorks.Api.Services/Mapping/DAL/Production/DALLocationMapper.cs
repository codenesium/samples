using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALLocationMapper : DALAbstractLocationMapper, IDALLocationMapper
	{
		public DALLocationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>05268db8d3c4731d06b3419decc89df5</Hash>
</Codenesium>*/