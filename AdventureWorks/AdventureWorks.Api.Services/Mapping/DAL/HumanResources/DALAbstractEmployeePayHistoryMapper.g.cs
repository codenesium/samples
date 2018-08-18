using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractEmployeePayHistoryMapper
	{
		public virtual EmployeePayHistory MapBOToEF(
			BOEmployeePayHistory bo)
		{
			EmployeePayHistory efEmployeePayHistory = new EmployeePayHistory();
			efEmployeePayHistory.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.PayFrequency,
				bo.Rate,
				bo.RateChangeDate);
			return efEmployeePayHistory;
		}

		public virtual BOEmployeePayHistory MapEFToBO(
			EmployeePayHistory ef)
		{
			var bo = new BOEmployeePayHistory();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PayFrequency,
				ef.Rate,
				ef.RateChangeDate);
			return bo;
		}

		public virtual List<BOEmployeePayHistory> MapEFToBO(
			List<EmployeePayHistory> records)
		{
			List<BOEmployeePayHistory> response = new List<BOEmployeePayHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de7b2f30ff09706285bf9e5fba8c372b</Hash>
</Codenesium>*/