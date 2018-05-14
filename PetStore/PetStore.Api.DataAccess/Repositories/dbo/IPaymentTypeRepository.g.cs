using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPaymentTypeRepository
	{
		POCOPaymentType Create(ApiPaymentTypeModel model);

		void Update(int id,
		            ApiPaymentTypeModel model);

		void Delete(int id);

		POCOPaymentType Get(int id);

		List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4884924c13df081a95eef892fa989979</Hash>
</Codenesium>*/