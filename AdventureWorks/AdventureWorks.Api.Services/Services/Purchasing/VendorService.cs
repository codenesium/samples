using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class VendorService : AbstractVendorService, IVendorService
	{
		public VendorService(
			ILogger<IVendorRepository> logger,
			IVendorRepository vendorRepository,
			IApiVendorServerRequestModelValidator vendorModelValidator,
			IBOLVendorMapper bolVendorMapper,
			IDALVendorMapper dalVendorMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base(logger,
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
    <Hash>8ea22180a3b246f123d08de848322d1f</Hash>
</Codenesium>*/