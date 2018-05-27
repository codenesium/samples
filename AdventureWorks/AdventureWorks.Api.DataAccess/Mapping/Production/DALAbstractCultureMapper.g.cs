using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCultureMapper
	{
		public virtual void MapDTOToEF(
			string cultureID,
			DTOCulture dto,
			Culture efCulture)
		{
			efCulture.SetProperties(
				cultureID,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOCulture MapEFToDTO(
			Culture ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCulture();

			dto.SetProperties(
				ef.CultureID,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>407f2b74279aad6e5b1a77164564c107</Hash>
</Codenesium>*/