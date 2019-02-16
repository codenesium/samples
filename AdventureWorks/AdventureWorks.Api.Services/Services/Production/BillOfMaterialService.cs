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
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base(logger,
			       mediator,
			       billOfMaterialRepository,
			       billOfMaterialModelValidator,
			       dalBillOfMaterialMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d873774074430d3aebddbcf1253a37c0</Hash>
</Codenesium>*/