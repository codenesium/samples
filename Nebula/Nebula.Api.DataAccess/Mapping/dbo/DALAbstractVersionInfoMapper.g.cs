using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALVersionInfoMapper
	{
		public virtual void MapDTOToEF(
			long version,
			DTOVersionInfo dto,
			VersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				dto.AppliedOn,
				dto.Description);
		}

		public virtual DTOVersionInfo MapEFToDTO(
			VersionInfo ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOVersionInfo();

			dto.SetProperties(
				ef.Version,
				ef.AppliedOn,
				ef.Description);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>a86b09e4bb810eb6f871b38f7655ab96</Hash>
</Codenesium>*/