using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClientCommunication
	{
		Task<CreateResponse<int>> Create(
			ClientCommunicationModel model);

		Task<ActionResponse> Update(int id,
		                            ClientCommunicationModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOClientCommunication GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClientCommunication> GetWhereDirect(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bde625d351ab7aeab8d24a25af80c469</Hash>
</Codenesium>*/