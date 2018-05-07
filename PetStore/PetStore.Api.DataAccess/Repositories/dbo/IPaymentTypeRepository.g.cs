using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPaymentTypeRepository
	{
		int Create(PaymentTypeModel model);

		void Update(int id,
		            PaymentTypeModel model);

		void Delete(int id);

		POCOPaymentType Get(int id);

		List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a95207e3354eaf50665d96e1ce101184</Hash>
</Codenesium>*/