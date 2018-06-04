using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALErrorLogMapper
	{
		public virtual ErrorLog MapBOToEF(
			BOErrorLog bo)
		{
			ErrorLog efErrorLog = new ErrorLog ();

			efErrorLog.SetProperties(
				bo.ErrorLine,
				bo.ErrorLogID,
				bo.ErrorMessage,
				bo.ErrorNumber,
				bo.ErrorProcedure,
				bo.ErrorSeverity,
				bo.ErrorState,
				bo.ErrorTime,
				bo.UserName);
			return efErrorLog;
		}

		public virtual BOErrorLog MapEFToBO(
			ErrorLog ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOErrorLog();

			bo.SetProperties(
				ef.ErrorLogID,
				ef.ErrorLine,
				ef.ErrorMessage,
				ef.ErrorNumber,
				ef.ErrorProcedure,
				ef.ErrorSeverity,
				ef.ErrorState,
				ef.ErrorTime,
				ef.UserName);
			return bo;
		}

		public virtual List<BOErrorLog> MapEFToBO(
			List<ErrorLog> records)
		{
			List<BOErrorLog> response = new List<BOErrorLog>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>22067c502a9ab0041972f03e6eb67230</Hash>
</Codenesium>*/