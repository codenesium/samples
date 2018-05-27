using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALCountryRequirementMapper
	{
		void MapDTOToEF(
			int id,
			DTOCountryRequirement dto,
			CountryRequirement efCountryRequirement);

		DTOCountryRequirement MapEFToDTO(
			CountryRequirement efCountryRequirement);
	}
}

/*<Codenesium>
    <Hash>0613d3eadee24e23eea70c903cdb1582</Hash>
</Codenesium>*/