using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		int Create(ClientCommunicationModel model);

		void Update(int id,
		            ClientCommunicationModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOClientCommunication GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClientCommunication> GetWhereDirect(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ef9e6b788a48b594285729f52269fabf</Hash>
</Codenesium>*/