using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSpecialOfferMapper
	{
		public virtual void MapDTOToEF(
			int specialOfferID,
			DTOSpecialOffer dto,
			SpecialOffer efSpecialOffer)
		{
			efSpecialOffer.SetProperties(
				specialOfferID,
				dto.Category,
				dto.Description,
				dto.DiscountPct,
				dto.EndDate,
				dto.MaxQty,
				dto.MinQty,
				dto.ModifiedDate,
				dto.Rowguid,
				dto.StartDate,
				dto.Type);
		}

		public virtual DTOSpecialOffer MapEFToDTO(
			SpecialOffer ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpecialOffer();

			dto.SetProperties(
				ef.SpecialOfferID,
				ef.Category,
				ef.Description,
				ef.DiscountPct,
				ef.EndDate,
				ef.MaxQty,
				ef.MinQty,
				ef.ModifiedDate,
				ef.Rowguid,
				ef.StartDate,
				ef.Type);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>072d7b269263711d1e0878f0869803bf</Hash>
</Codenesium>*/