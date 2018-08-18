using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractProductModelIllustrationMapper
	{
		public virtual ProductModelIllustration MapBOToEF(
			BOProductModelIllustration bo)
		{
			ProductModelIllustration efProductModelIllustration = new ProductModelIllustration();
			efProductModelIllustration.SetProperties(
				bo.IllustrationID,
				bo.ModifiedDate,
				bo.ProductModelID);
			return efProductModelIllustration;
		}

		public virtual BOProductModelIllustration MapEFToBO(
			ProductModelIllustration ef)
		{
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
    <Hash>2b05db8f7548fa96d20f8005cbf5fb61</Hash>
</Codenesium>*/