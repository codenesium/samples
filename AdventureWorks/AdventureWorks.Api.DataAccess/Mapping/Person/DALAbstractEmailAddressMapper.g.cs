using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALEmailAddressMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOEmailAddress dto,
			EmailAddress efEmailAddress)
		{
			efEmailAddress.SetProperties(
				businessEntityID,
				dto.EmailAddress1,
				dto.EmailAddressID,
				dto.ModifiedDate,
				dto.Rowguid);
		}

		public virtual DTOEmailAddress MapEFToDTO(
			EmailAddress ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOEmailAddress();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.EmailAddress1,
				ef.EmailAddressID,
				ef.ModifiedDate,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>fb618d26fbea8c92c5614262d244392c</Hash>
</Codenesium>*/