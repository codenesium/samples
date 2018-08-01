using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALBillOfMaterialMapper : DALAbstractBillOfMaterialMapper, IDALBillOfMaterialMapper
	{
		public DALBillOfMaterialMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c318bac772db9be9dadb242bcfd9f49</Hash>
</Codenesium>*/