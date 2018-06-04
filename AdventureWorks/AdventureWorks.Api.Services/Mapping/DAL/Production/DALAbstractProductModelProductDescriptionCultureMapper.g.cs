using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductModelProductDescriptionCultureMapper
	{
		public virtual ProductModelProductDescriptionCulture MapBOToEF(
			BOProductModelProductDescriptionCulture bo)
		{
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>af6a257d6dc1851b967c50070f5992fc</Hash>
</Codenesium>*/