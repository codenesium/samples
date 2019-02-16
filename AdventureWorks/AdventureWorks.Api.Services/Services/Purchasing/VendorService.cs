using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class VendorService : AbstractVendorService, IVendorService
	{
		public VendorService(
			ILogger<IVendorRepository> logger,
			IMediator mediator,
			IVendorRepository vendorRepository,
			IApiVendorServerRequestModelValidator vendorModelValidator,
			IDALVendorMapper dalVendorMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
			       mediator,
			       vendorRepository,
			       vendorModelValidator,
			       dalVendorMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cc109824892fe0aff46eb93545eb87a6</Hash>
</Codenesium>*/