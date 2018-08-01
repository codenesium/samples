using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSpecialOfferProductMapper
	{
		public virtual SpecialOfferProduct MapBOToEF(
			BOSpecialOfferProduct bo)
		{
			SpecialOfferProduct efSpecialOfferProduct = new SpecialOfferProduct();
			efSpecialOfferProduct.SetProperties(
				bo.ModifiedDate,
				bo.ProductID,
				bo.Rowguid,
				bo.SpecialOfferID);
			return efSpecialOfferProduct;
		}

		public virtual BOSpecialOfferProduct MapEFToBO(
			SpecialOfferProduct ef)
		{
			var bo = new BOSpecialOfferProduct();

			bo.SetProperties(
				ef.SpecialOfferID,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOSpecialOfferProduct> MapEFToBO(
			List<SpecialOfferProduct> records)
		{
			List<BOSpecialOfferProduct> response = new List<BOSpecialOfferProduct>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e4dcf26ef5752769f590f28163a7a49f</Hash>
</Codenesium>*/