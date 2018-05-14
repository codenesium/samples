using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		POCOClientCommunication Create(ClientCommunicationModel model);

		void Update(int id,
		            ClientCommunicationModel model);

		void Delete(int id);

		POCOClientCommunication Get(int id);

		List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dab1ab2e63779994af99567b05fac9a1</Hash>
</Codenesium>*/