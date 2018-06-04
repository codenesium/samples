using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductProductPhotoMapper
	{
		public virtual ProductProductPhoto MapBOToEF(
			BOProductProductPhoto bo)
		{
			ProductProductPhoto efProductProductPhoto = new ProductProductPhoto ();

			efProductProductPhoto.SetProperties(
				bo.ModifiedDate,
				bo.Primary,
				bo.ProductID,
				bo.ProductPhotoID);
			return efProductProductPhoto;
		}

		public virtual BOProductProductPhoto MapEFToBO(
			ProductProductPhoto ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOProductProductPhoto();

			bo.SetProperties(
				ef.ProductID,
				ef.ModifiedDate,
				ef.Primary,
				ef.ProductPhotoID);
			return bo;
		}

		public virtual List<BOProductProductPhoto> MapEFToBO(
			List<ProductProductPhoto> records)
		{
			List<BOProductProductPhoto> response = new List<BOProductProductPhoto>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bdc55880dc4e2d988d9f897291639816</Hash>
</Codenesium>*/