using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		Task<DTOClientCommunication> Create(DTOClientCommunication dto);

		Task Update(int id,
		            DTOClientCommunication dto);

		Task Delete(int id);

		Task<DTOClientCommunication> Get(int id);

		Task<List<DTOClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d4121c78edcb0070826406a453ea2aff</Hash>
</Codenesium>*/