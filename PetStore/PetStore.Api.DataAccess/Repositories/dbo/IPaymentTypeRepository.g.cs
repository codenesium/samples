using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPaymentTypeRepository
	{
		POCOPaymentType Create(PaymentTypeModel model);

		void Update(int id,
		            PaymentTypeModel model);

		void Delete(int id);

		POCOPaymentType Get(int id);

		List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>786185612aa245ad0ca2054354646113</Hash>
</Codenesium>*/