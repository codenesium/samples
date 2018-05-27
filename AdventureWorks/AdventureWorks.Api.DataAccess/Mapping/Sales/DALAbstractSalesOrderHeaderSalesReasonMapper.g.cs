using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesOrderHeaderSalesReasonMapper
	{
		public virtual void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderHeaderSalesReason dto,
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason)
		{
			efSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				dto.ModifiedDate,
				dto.SalesReasonID);
		}

		public virtual DTOSalesOrderHeaderSalesReason MapEFToDTO(
			SalesOrderHeaderSalesReason ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesOrderHeaderSalesReason();

			dto.SetProperties(
				ef.SalesOrderID,
				ef.ModifiedDate,
				ef.SalesReasonID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>bf040f32f8dd292aaf36df64ebcde70e</Hash>
</Codenesium>*/