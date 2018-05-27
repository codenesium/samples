using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALEmployeePayHistoryMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOEmployeePayHistory dto,
			EmployeePayHistory efEmployeePayHistory)
		{
			efEmployeePayHistory.SetProperties(
				businessEntityID,
				dto.ModifiedDate,
				dto.PayFrequency,
				dto.Rate,
				dto.RateChangeDate);
		}

		public virtual DTOEmployeePayHistory MapEFToDTO(
			EmployeePayHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOEmployeePayHistory();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PayFrequency,
				ef.Rate,
				ef.RateChangeDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>376bc2d42282cfee7c9513f43e23f9ff</Hash>
</Codenesium>*/