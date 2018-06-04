using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCurrencyRateMapper
	{
		public virtual CurrencyRate MapBOToEF(
			BOCurrencyRate bo)
		{
			CurrencyRate efCurrencyRate = new CurrencyRate ();

			efCurrencyRate.SetProperties(
				bo.AverageRate,
				bo.CurrencyRateDate,
				bo.CurrencyRateID,
				bo.EndOfDayRate,
				bo.FromCurrencyCode,
				bo.ModifiedDate,
				bo.ToCurrencyCode);
			return efCurrencyRate;
		}

		public virtual BOCurrencyRate MapEFToBO(
			CurrencyRate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOCurrencyRate();

			bo.SetProperties(
				ef.CurrencyRateID,
				ef.AverageRate,
				ef.CurrencyRateDate,
				ef.EndOfDayRate,
				ef.FromCurrencyCode,
				ef.ModifiedDate,
				ef.ToCurrencyCode);
			return bo;
		}

		public virtual List<BOCurrencyRate> MapEFToBO(
			List<CurrencyRate> records)
		{
			List<BOCurrencyRate> response = new List<BOCurrencyRate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d99eadbf70ca425b388346cd0fccf7ec</Hash>
</Codenesium>*/