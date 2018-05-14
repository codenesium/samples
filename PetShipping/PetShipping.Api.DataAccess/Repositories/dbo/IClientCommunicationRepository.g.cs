using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		POCOClientCommunication Create(ApiClientCommunicationModel model);

		void Update(int id,
		            ApiClientCommunicationModel model);

		void Delete(int id);

		POCOClientCommunication Get(int id);

		List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7c82c620c4bdc24e491fe1ec158f595d</Hash>
</Codenesium>*/