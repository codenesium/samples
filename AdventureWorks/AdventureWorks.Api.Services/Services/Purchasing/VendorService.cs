using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class VendorService : AbstractVendorService, IVendorService
	{
		public VendorService(
			ILogger<IVendorRepository> logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper bolvendorMapper,
			IDALVendorMapper dalvendorMapper,
			IBOLProductVendorMapper bolProductVendorMapper,
			IDALProductVendorMapper dalProductVendorMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper
			)
			: base(logger,
			       vendorRepository,
			       vendorModelValidator,
			       bolvendorMapper,
			       dalvendorMapper,
			       bolProductVendorMapper,
			       dalProductVendorMapper,
			       bolPurchaseOrderHeaderMapper,
			       dalPurchaseOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>86891093bbadc6eea2f2a614b60699f1</Hash>
</Codenesium>*/