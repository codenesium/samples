using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesPersonQuotaHistoryMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOSalesPersonQuotaHistory dto,
			SalesPersonQuotaHistory efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				dto.ModifiedDate,
				dto.QuotaDate,
				dto.Rowguid,
				dto.SalesQuota);
		}

		public virtual DTOSalesPersonQuotaHistory MapEFToDTO(
			SalesPersonQuotaHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesPersonQuotaHistory();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.QuotaDate,
				ef.Rowguid,
				ef.SalesQuota);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>6ffb63a5266e99affc08ff3643394441</Hash>
</Codenesium>*/