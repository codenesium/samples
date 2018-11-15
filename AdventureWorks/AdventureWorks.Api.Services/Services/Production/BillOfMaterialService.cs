using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class BillOfMaterialService : AbstractBillOfMaterialService, IBillOfMaterialService
	{
		public BillOfMaterialService(
			ILogger<IBillOfMaterialRepository> logger,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialServerRequestModelValidator billOfMaterialModelValidator,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base(logger,
			       billOfMaterialRepository,
			       billOfMaterialModelValidator,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>32dbac41e4d017cfab38aa7a740f22b9</Hash>
</Codenesium>*/