using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductModelProductDescriptionCultureMapper
	{
		public virtual ProductModelProductDescriptionCulture MapBOToEF(
			BOProductModelProductDescriptionCulture bo)
		{
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
			efProductModelProductDescriptionCulture.SetProperties(
				bo.CultureID,
				bo.ModifiedDate,
				bo.ProductDescriptionID,
				bo.ProductModelID);
			return efProductModelProductDescriptionCulture;
		}

		public virtual BOProductModelProductDescriptionCulture MapEFToBO(
			ProductModelProductDescriptionCulture ef)
		{
			var bo = new BOProductModelProductDescriptionCulture();

			bo.SetProperties(
				ef.ProductModelID,
				ef.CultureID,
				ef.ModifiedDate,
				ef.ProductDescriptionID);
			return bo;
		}

		public virtual List<BOProductModelProductDescriptionCulture> MapEFToBO(
			List<ProductModelProductDescriptionCulture> records)
		{
			List<BOProductModelProductDescriptionCulture> response = new List<BOProductModelProductDescriptionCulture>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>995a245bb6cb6735b25a6685fb7c4386</Hash>
</Codenesium>*/