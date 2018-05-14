using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		POCOContactType Create(ApiContactTypeModel model);

		void Update(int contactTypeID,
		            ApiContactTypeModel model);

		void Delete(int contactTypeID);

		POCOContactType Get(int contactTypeID);

		List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOContactType GetName(string name);
	}
}

/*<Codenesium>
    <Hash>2e34a602114153eab878828c3f044f04</Hash>
</Codenesium>*/