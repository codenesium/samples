using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductDescriptionMapper
	{
		public virtual ProductDescription MapBOToEF(
			BOProductDescription bo)
		{
			ProductDescription efProductDescription = new ProductDescription();
			efProductDescription.SetProperties(
				bo.Description,
				bo.ModifiedDate,
				bo.ProductDescriptionID,
				bo.Rowguid);
			return efProductDescription;
		}

		public virtual BOProductDescription MapEFToBO(
			ProductDescription ef)
		{
			var bo = new BOProductDescription();

			bo.SetProperties(
				ef.ProductDescriptionID,
				ef.Description,
				ef.ModifiedDate,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOProductDescription> MapEFToBO(
			List<ProductDescription> records)
		{
			List<BOProductDescription> response = new List<BOProductDescription>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>38d58856f64e9726017a1b6e3656dff1</Hash>
</Codenesium>*/