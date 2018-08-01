using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductListPriceHistoryMapper
	{
		public virtual ProductListPriceHistory MapBOToEF(
			BOProductListPriceHistory bo)
		{
			ProductListPriceHistory efProductListPriceHistory = new ProductListPriceHistory();
			efProductListPriceHistory.SetProperties(
				bo.EndDate,
				bo.ListPrice,
				bo.ModifiedDate,
				bo.ProductID,
				bo.StartDate);
			return efProductListPriceHistory;
		}

		public virtual BOProductListPriceHistory MapEFToBO(
			ProductListPriceHistory ef)
		{
			var bo = new BOProductListPriceHistory();

			bo.SetProperties(
				ef.ProductID,
				ef.EndDate,
				ef.ListPrice,
				ef.ModifiedDate,
				ef.StartDate);
			return bo;
		}

		public virtual List<BOProductListPriceHistory> MapEFToBO(
			List<ProductListPriceHistory> records)
		{
			List<BOProductListPriceHistory> response = new List<BOProductListPriceHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>20a59bd17dd6a90758e3e121fc8fa734</Hash>
</Codenesium>*/