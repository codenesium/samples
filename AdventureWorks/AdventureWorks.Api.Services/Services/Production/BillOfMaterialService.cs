using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class BillOfMaterialService : AbstractBillOfMaterialService, IBillOfMaterialService
	{
		public BillOfMaterialService(
			ILogger<IBillOfMaterialRepository> logger,
			IMediator mediator,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialServerRequestModelValidator billOfMaterialModelValidator,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base(logger,
			       mediator,
			       billOfMaterialRepository,
			       billOfMaterialModelValidator,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5a9c2350e739e4279eb8090b29a54fc8</Hash>
</Codenesium>*/