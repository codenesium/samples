using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductModelMapper
	{
		public virtual ProductModel MapBOToEF(
			BOProductModel bo)
		{
			ProductModel efProductModel = new ProductModel ();

			efProductModel.SetProperties(
				bo.CatalogDescription,
				bo.Instructions,
				bo.ModifiedDate,
				bo.Name,
				bo.ProductModelID,
				bo.Rowguid);
			return efProductModel;
		}

		public virtual BOProductModel MapEFToBO(
			ProductModel ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOProductModel();

			bo.SetProperties(
				ef.ProductModelID,
				ef.CatalogDescription,
				ef.Instructions,
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
    <Hash>50fd31104ce1fdd020902967ea426f52</Hash>
</Codenesium>*/