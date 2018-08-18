using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductVendorMapper
	{
		public virtual ProductVendor MapBOToEF(
			BOProductVendor bo)
		{
			ProductVendor efProductVendor = new ProductVendor();
			efProductVendor.SetProperties(
				bo.AverageLeadTime,
				bo.BusinessEntityID,
				bo.LastReceiptCost,
				bo.LastReceiptDate,
				bo.MaxOrderQty,
				bo.MinOrderQty,
				bo.ModifiedDate,
				bo.OnOrderQty,
				bo.ProductID,
				bo.StandardPrice,
				bo.UnitMeasureCode);
			return efProductVendor;
		}

		public virtual BOProductVendor MapEFToBO(
			ProductVendor ef)
		{
			var bo = new BOProductVendor();

			bo.SetProperties(
				ef.ProductID,
				ef.AverageLeadTime,
				ef.BusinessEntityID,
				ef.LastReceiptCost,
				ef.LastReceiptDate,
				ef.MaxOrderQty,
				ef.MinOrderQty,
				ef.ModifiedDate,
				ef.OnOrderQty,
				ef.StandardPrice,
				ef.UnitMeasureCode);
			return bo;
		}

		public virtual List<BOProductVendor> MapEFToBO(
			List<ProductVendor> records)
		{
			List<BOProductVendor> response = new List<BOProductVendor>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ced480939349e9c5cf357b987d741077</Hash>
</Codenesium>*/