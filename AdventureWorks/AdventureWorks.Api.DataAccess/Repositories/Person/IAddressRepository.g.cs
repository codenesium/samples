using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		int Create(AddressModel model);

		void Update(int addressID,
		            AddressModel model);

		void Delete(int addressID);

		POCOAddress Get(int addressID);

		List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5839398c83acb369717c2160b2ef4b71</Hash>
</Codenesium>*/