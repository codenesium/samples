using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		POCODestination Create(DestinationModel model);

		void Update(int id,
		            DestinationModel model);

		void Delete(int id);

		POCODestination Get(int id);

		List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>971247cfc8ce8e7c7186bb55f863b861</Hash>
</Codenesium>*/