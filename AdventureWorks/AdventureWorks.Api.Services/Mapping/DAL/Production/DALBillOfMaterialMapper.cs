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
    <Hash>edaf0d6e93c9b9ae250f34d77920efa1</Hash>
</Codenesium>*/