using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBusinessEntityMapper
	{
		public virtual BusinessEntity MapBOToEF(
			BOBusinessEntity bo)
		{
			BusinessEntity efBusinessEntity = new BusinessEntity ();

			efBusinessEntity.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.Rowguid);
			return efBusinessEntity;
		}

		public virtual BOBusinessEntity MapEFToBO(
			BusinessEntity ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOBusinessEntity();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOBusinessEntity> MapEFToBO(
			List<BusinessEntity> records)
		{
			List<BOBusinessEntity> response = new List<BOBusinessEntity>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7299436f3ea789ff47aba86064038b4a</Hash>
</Codenesium>*/