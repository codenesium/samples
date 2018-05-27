using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSpecialOfferProductMapper
	{
		public virtual void MapDTOToEF(
			int specialOfferID,
			DTOSpecialOfferProduct dto,
			SpecialOfferProduct efSpecialOfferProduct)
		{
			efSpecialOfferProduct.SetProperties(
				specialOfferID,
				dto.ModifiedDate,
				dto.ProductID,
				dto.Rowguid);
		}

		public virtual DTOSpecialOfferProduct MapEFToDTO(
			SpecialOfferProduct ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpecialOfferProduct();

			dto.SetProperties(
				ef.SpecialOfferID,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>d0e4272d22168ed8ee62bce76e4682e6</Hash>
</Codenesium>*/