using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		Task<POCOPhoneNumberType> Create(ApiPhoneNumberTypeModel model);

		Task Update(int phoneNumberTypeID,
		            ApiPhoneNumberTypeModel model);

		Task Delete(int phoneNumberTypeID);

		Task<POCOPhoneNumberType> Get(int phoneNumberTypeID);

		Task<List<POCOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cc8907497551c5a5c462e1b362a4cc65</Hash>
</Codenesium>*/