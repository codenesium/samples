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
			IBOLVendorMapper bolVendorMapper,
			IDALVendorMapper dalVendorMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
			       mediator,
			       vendorRepository,
			       vendorModelValidator,
			       bolVendorMapper,
			       dalVendorMapper,
			       bolPurchaseOrderHeaderMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>255fe723d71682374152c0e8b471a851</Hash>
</Codenesium>*/