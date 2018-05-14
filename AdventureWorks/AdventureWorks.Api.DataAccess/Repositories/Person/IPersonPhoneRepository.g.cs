using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		POCOPersonPhone Create(ApiPersonPhoneModel model);

		void Update(int businessEntityID,
		            ApiPersonPhoneModel model);

		void Delete(int businessEntityID);

		POCOPersonPhone Get(int businessEntityID);

		List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonPhone> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>b8c25aeccb46fb26fc789d5ecf06cd9c</Hash>
</Codenesium>*/