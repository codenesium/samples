using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPhoneNumberTypeMapper
	{
		public virtual PhoneNumberType MapBOToEF(
			BOPhoneNumberType bo)
		{
			PhoneNumberType efPhoneNumberType = new PhoneNumberType();
			efPhoneNumberType.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.PhoneNumberTypeID);
			return efPhoneNumberType;
		}

		public virtual BOPhoneNumberType MapEFToBO(
			PhoneNumberType ef)
		{
			var bo = new BOPhoneNumberType();

			bo.SetProperties(
				ef.PhoneNumberTypeID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOPhoneNumberType> MapEFToBO(
			List<PhoneNumberType> records)
		{
			List<BOPhoneNumberType> response = new List<BOPhoneNumberType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>615c1e502e98647f617b9dfebde143a7</Hash>
</Codenesium>*/