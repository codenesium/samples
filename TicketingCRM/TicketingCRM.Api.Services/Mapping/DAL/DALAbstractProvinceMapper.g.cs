using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractProvinceMapper
	{
		public virtual Province MapBOToEF(
			BOProvince bo)
		{
			Province efProvince = new Province();
			efProvince.SetProperties(
				bo.CountryId,
				bo.Id,
				bo.Name);
			return efProvince;
		}

		public virtual BOProvince MapEFToBO(
			Province ef)
		{
			var bo = new BOProvince();

			bo.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Name);
			return bo;
		}

		public virtual List<BOProvince> MapEFToBO(
			List<Province> records)
		{
			List<BOProvince> response = new List<BOProvince>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ad646bfebab4cc77fdd0f0e0db404444</Hash>
</Codenesium>*/