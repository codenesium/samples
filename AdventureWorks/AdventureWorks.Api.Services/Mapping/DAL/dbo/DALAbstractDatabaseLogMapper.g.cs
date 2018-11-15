using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractDatabaseLogMapper
	{
		public virtual DatabaseLog MapBOToEF(
			BODatabaseLog bo)
		{
			DatabaseLog efDatabaseLog = new DatabaseLog();
			efDatabaseLog.SetProperties(
				bo.@Event,
				bo.@Object,
				bo.DatabaseLogID,
				bo.DatabaseUser,
				bo.PostTime,
				bo.Schema,
				bo.Tsql,
				bo.XmlEvent);
			return efDatabaseLog;
		}

		public virtual BODatabaseLog MapEFToBO(
			DatabaseLog ef)
		{
			var bo = new BODatabaseLog();

			bo.SetProperties(
				ef.DatabaseLogID,
				ef.@Event,
				ef.@Object,
				ef.DatabaseUser,
				ef.PostTime,
				ef.Schema,
				ef.Tsql,
				ef.XmlEvent);
			return bo;
		}

		public virtual List<BODatabaseLog> MapEFToBO(
			List<DatabaseLog> records)
		{
			List<BODatabaseLog> response = new List<BODatabaseLog>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8088a9452aa55855806b90d22f52fd92</Hash>
</Codenesium>*/