using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductDescriptionMapper : DALAbstractProductDescriptionMapper, IDALProductDescriptionMapper
	{
		public DALProductDescriptionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>31592e89bdd661fa294a43f489877186</Hash>
</Codenesium>*/