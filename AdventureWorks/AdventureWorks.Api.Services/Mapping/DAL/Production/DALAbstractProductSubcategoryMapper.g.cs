using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductSubcategoryMapper
	{
		public virtual ProductSubcategory MapBOToEF(
			BOProductSubcategory bo)
		{
			ProductSubcategory efProductSubcategory = new ProductSubcategory();
			efProductSubcategory.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.ProductCategoryID,
				bo.ProductSubcategoryID,
				bo.Rowguid);
			return efProductSubcategory;
		}

		public virtual BOProductSubcategory MapEFToBO(
			ProductSubcategory ef)
		{
			var bo = new BOProductSubcategory();

			bo.SetProperties(
				ef.ProductSubcategoryID,
				ef.ModifiedDate,
				ef.Name,
				ef.ProductCategoryID,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOProductSubcategory> MapEFToBO(
			List<ProductSubcategory> records)
		{
			List<BOProductSubcategory> response = new List<BOProductSubcategory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fb0d0053d6557fbd72b27f5b7d66bf02</Hash>
</Codenesium>*/