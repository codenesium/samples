using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALDatabaseLogMapper
	{
		public virtual void MapDTOToEF(
			int databaseLogID,
			DTODatabaseLog dto,
			DatabaseLog efDatabaseLog)
		{
			efDatabaseLog.SetProperties(
				databaseLogID,
				dto.DatabaseUser,
				dto.@Event,
				dto.@Object,
				dto.PostTime,
				dto.Schema,
				dto.TSQL,
				dto.XmlEvent);
		}

		public virtual DTODatabaseLog MapEFToDTO(
			DatabaseLog ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODatabaseLog();

			dto.SetProperties(
				ef.DatabaseLogID,
				ef.DatabaseUser,
				ef.@Event,
				ef.@Object,
				ef.PostTime,
				ef.Schema,
				ef.TSQL,
				ef.XmlEvent);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>66bf284843a86a116d41b916bd86f4dd</Hash>
</Codenesium>*/