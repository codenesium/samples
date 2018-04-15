using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		int Create(StudioModel model);

		void Update(int id,
		            StudioModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOStudio GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudio> GetWhereDirect(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8ea87a9a4f360e9bd71150dcde8f26c2</Hash>
</Codenesium>*/