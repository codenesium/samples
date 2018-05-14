using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		POCOFamily Create(ApiFamilyModel model);

		void Update(int id,
		            ApiFamilyModel model);

		void Delete(int id);

		POCOFamily Get(int id);

		List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fbc86fc17b925fb7e3c457cb534c5e4f</Hash>
</Codenesium>*/