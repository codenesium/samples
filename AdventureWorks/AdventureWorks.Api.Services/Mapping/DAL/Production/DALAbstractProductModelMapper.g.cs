using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductModelMapper
	{
		public virtual ProductModel MapBOToEF(
			BOProductModel bo)
		{
			ProductModel efProductModel = new ProductModel();
			efProductModel.SetProperties(
				bo.CatalogDescription,
				bo.Instruction,
				bo.ModifiedDate,
				bo.Name,
				bo.ProductModelID,
				bo.Rowguid);
			return efProductModel;
		}

		public virtual BOProductModel MapEFToBO(
			ProductModel ef)
		{
			var bo = new BOProductModel();

			bo.SetProperties(
				ef.ProductModelID,
				ef.CatalogDescription,
				ef.Instruction,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOProductModel> MapEFToBO(
			List<ProductModel> records)
		{
			List<BOProductModel> response = new List<BOProductModel>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b2396d367d17531b789bb354c7e0dd73</Hash>
</Codenesium>*/