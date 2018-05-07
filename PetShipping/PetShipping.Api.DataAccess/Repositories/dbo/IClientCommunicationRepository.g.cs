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

		POCOClientCommunication Get(int id);

		List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6e4d13ce72083be2ba0e521ea20290c3</Hash>
</Codenesium>*/