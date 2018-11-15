using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractBusinessEntityMapper
	{
		public virtual BusinessEntity MapBOToEF(
			BOBusinessEntity bo)
		{
			BusinessEntity efBusinessEntity = new BusinessEntity();
			efBusinessEntity.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.Rowguid);
			return efBusinessEntity;
		}

		public virtual BOBusinessEntity MapEFToBO(
			BusinessEntity ef)
		{
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
    <Hash>370ee9767eb8fed7b501a18fde0fbc0d</Hash>
</Codenesium>*/