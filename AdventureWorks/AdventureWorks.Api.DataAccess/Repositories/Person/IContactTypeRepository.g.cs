using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		int Create(ContactTypeModel model);

		void Update(int contactTypeID,
		            ContactTypeModel model);

		void Delete(int contactTypeID);

		POCOContactType Get(int contactTypeID);

		List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>023eb15d84cdc2bcff320a52b23dcd94</Hash>
</Codenesium>*/