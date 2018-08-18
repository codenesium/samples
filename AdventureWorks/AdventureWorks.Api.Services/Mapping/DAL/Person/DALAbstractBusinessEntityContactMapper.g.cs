using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractBusinessEntityContactMapper
	{
		public virtual BusinessEntityContact MapBOToEF(
			BOBusinessEntityContact bo)
		{
			BusinessEntityContact efBusinessEntityContact = new BusinessEntityContact();
			efBusinessEntityContact.SetProperties(
				bo.BusinessEntityID,
				bo.ContactTypeID,
				bo.ModifiedDate,
				bo.PersonID,
				bo.Rowguid);
			return efBusinessEntityContact;
		}

		public virtual BOBusinessEntityContact MapEFToBO(
			BusinessEntityContact ef)
		{
			var bo = new BOBusinessEntityContact();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ContactTypeID,
				ef.ModifiedDate,
				ef.PersonID,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOBusinessEntityContact> MapEFToBO(
			List<BusinessEntityContact> records)
		{
			List<BOBusinessEntityContact> response = new List<BOBusinessEntityContact>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87a200e8f26359fd664526cc7e2c20cc</Hash>
</Codenesium>*/