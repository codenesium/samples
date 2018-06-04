using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductModelIllustrationMapper
	{
		public virtual ProductModelIllustration MapBOToEF(
			BOProductModelIllustration bo)
		{
			ProductModelIllustration efProductModelIllustration = new ProductModelIllustration ();

			efProductModelIllustration.SetProperties(
				bo.IllustrationID,
				bo.ModifiedDate,
				bo.ProductModelID);
			return efProductModelIllustration;
		}

		public virtual BOProductModelIllustration MapEFToBO(
			ProductModelIllustration ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOProductModelIllustration();

			bo.SetProperties(
				ef.ProductModelID,
				ef.IllustrationID,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOProductModelIllustration> MapEFToBO(
			List<ProductModelIllustration> records)
		{
			List<BOProductModelIllustration> response = new List<BOProductModelIllustration>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>520e16fd1f66be82b4b7c24c0cda08fa</Hash>
</Codenesium>*/