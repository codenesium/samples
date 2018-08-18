using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALBusinessEntityMapper : DALAbstractBusinessEntityMapper, IDALBusinessEntityMapper
	{
		public DALBusinessEntityMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>58fb7a6c12154f369be4dd025ad13e23</Hash>
</Codenesium>*/