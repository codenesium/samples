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
    <Hash>375986d6afe9dedd16873ed37e85ad31</Hash>
</Codenesium>*/