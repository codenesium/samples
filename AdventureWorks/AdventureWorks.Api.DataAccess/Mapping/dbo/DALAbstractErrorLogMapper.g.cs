using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALErrorLogMapper
	{
		public virtual void MapDTOToEF(
			int errorLogID,
			DTOErrorLog dto,
			ErrorLog efErrorLog)
		{
			efErrorLog.SetProperties(
				errorLogID,
				dto.ErrorLine,
				dto.ErrorMessage,
				dto.ErrorNumber,
				dto.ErrorProcedure,
				dto.ErrorSeverity,
				dto.ErrorState,
				dto.ErrorTime,
				dto.UserName);
		}

		public virtual DTOErrorLog MapEFToDTO(
			ErrorLog ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOErrorLog();

			dto.SetProperties(
				ef.ErrorLogID,
				ef.ErrorLine,
				ef.ErrorMessage,
				ef.ErrorNumber,
				ef.ErrorProcedure,
				ef.ErrorSeverity,
				ef.ErrorState,
				ef.ErrorTime,
				ef.UserName);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>fc2a0f76a86e2bce4d68e6754a604f53</Hash>
</Codenesium>*/