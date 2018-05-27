using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPersonMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOPerson dto,
			Person efPerson)
		{
			efPerson.SetProperties(
				businessEntityID,
				dto.AdditionalContactInfo,
				dto.Demographics,
				dto.EmailPromotion,
				dto.FirstName,
				dto.LastName,
				dto.MiddleName,
				dto.ModifiedDate,
				dto.NameStyle,
				dto.PersonType,
				dto.Rowguid,
				dto.Suffix,
				dto.Title);
		}

		public virtual DTOPerson MapEFToDTO(
			Person ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPerson();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.AdditionalContactInfo,
				ef.Demographics,
				ef.EmailPromotion,
				ef.FirstName,
				ef.LastName,
				ef.MiddleName,
				ef.ModifiedDate,
				ef.NameStyle,
				ef.PersonType,
				ef.Rowguid,
				ef.Suffix,
				ef.Title);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>2fead800585febc16e5db769e736c085</Hash>
</Codenesium>*/