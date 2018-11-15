using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class DALStudioMapper : DALAbstractStudioMapper, IDALStudioMapper
	{
		public DALStudioMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>02b7fa79643cc43fa71231a5830283cc</Hash>
</Codenesium>*/