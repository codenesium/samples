using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractVProductAndDescriptionMapper
	{
		public virtual VProductAndDescription MapBOToEF(
			BOVProductAndDescription bo)
		{
			VProductAndDescription efVProductAndDescription = new VProductAndDescription();
			efVProductAndDescription.SetProperties(
				bo.CultureID,
				bo.Description,
				bo.Name,
				bo.ProductID,
				bo.ProductModel);
			return efVProductAndDescription;
		}

		public virtual BOVProductAndDescription MapEFToBO(
			VProductAndDescription ef)
		{
			var bo = new BOVProductAndDescription();

			bo.SetProperties(
				ef.CultureID,
				ef.Description,
				ef.Name,
				ef.ProductID,
				ef.ProductModel);
			return bo;
		}

		public virtual List<BOVProductAndDescription> MapEFToBO(
			List<VProductAndDescription> records)
		{
			List<BOVProductAndDescription> response = new List<BOVProductAndDescription>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9486adf787fcbf46436b7dfd661150fe</Hash>
</Codenesium>*/