using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPersonPhoneMapper
	{
		public virtual PersonPhone MapBOToEF(
			BOPersonPhone bo)
		{
			PersonPhone efPersonPhone = new PersonPhone ();

			efPersonPhone.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.PhoneNumber,
				bo.PhoneNumberTypeID);
			return efPersonPhone;
		}

		public virtual BOPersonPhone MapEFToBO(
			PersonPhone ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPersonPhone();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PhoneNumber,
				ef.PhoneNumberTypeID);
			return bo;
		}

		public virtual List<BOPersonPhone> MapEFToBO(
			List<PersonPhone> records)
		{
			List<BOPersonPhone> response = new List<BOPersonPhone>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0520c19896f07f0fef056aae833bba3d</Hash>
</Codenesium>*/