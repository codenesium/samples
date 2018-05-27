using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPaymentTypeRepository
	{
		Task<DTOPaymentType> Create(DTOPaymentType dto);

		Task Update(int id,
		            DTOPaymentType dto);

		Task Delete(int id);

		Task<DTOPaymentType> Get(int id);

		Task<List<DTOPaymentType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3bbc989d4d72fbce57835663a006ef11</Hash>
</Codenesium>*/