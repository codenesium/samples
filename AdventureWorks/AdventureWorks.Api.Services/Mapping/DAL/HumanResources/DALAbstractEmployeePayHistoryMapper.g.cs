using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALEmployeePayHistoryMapper
	{
		public virtual EmployeePayHistory MapBOToEF(
			BOEmployeePayHistory bo)
		{
			EmployeePayHistory efEmployeePayHistory = new EmployeePayHistory ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>e6f070334d5c76e4bb5a34a53059f0de</Hash>
</Codenesium>*/