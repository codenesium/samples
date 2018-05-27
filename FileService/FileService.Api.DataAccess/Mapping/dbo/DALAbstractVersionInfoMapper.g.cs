using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
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
    <Hash>657b2be417c660618bbcd524a97e0fdc</Hash>
</Codenesium>*/