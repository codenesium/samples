using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALCountryRequirementMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOCountryRequirement dto,
			CountryRequirement efCountryRequirement)
		{
			efCountryRequirement.SetProperties(
				id,
				dto.CountryId,
				dto.Details);
		}

		public virtual DTOCountryRequirement MapEFToDTO(
			CountryRequirement ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCountryRequirement();

			dto.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Details);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>0a47f04079fa43b2db187a99ec507f31</Hash>
</Codenesium>*/