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

		ApiResponse GetById(int id);

		POCOPaymentType GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPaymentType> GetWhereDirect(Expression<Func<EFPaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>74a9822c0be859f94f86e86b6e833575</Hash>
</Codenesium>*/