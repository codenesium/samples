using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALAWBuildVersionMapper
	{
		public virtual void MapDTOToEF(
			int systemInformationID,
			DTOAWBuildVersion dto,
			AWBuildVersion efAWBuildVersion)
		{
			efAWBuildVersion.SetProperties(
				systemInformationID,
				dto.Database_Version,
				dto.ModifiedDate,
				dto.VersionDate);
		}

		public virtual DTOAWBuildVersion MapEFToDTO(
			AWBuildVersion ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAWBuildVersion();

			dto.SetProperties(
				ef.SystemInformationID,
				ef.Database_Version,
				ef.ModifiedDate,
				ef.VersionDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>41815d08a5dc6a1ef02a06c7df13f74e</Hash>
</Codenesium>*/