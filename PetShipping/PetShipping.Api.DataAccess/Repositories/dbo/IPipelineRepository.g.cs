using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		int Create(PipelineModel model);

		void Update(int id,
		            PipelineModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipeline GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipeline> GetWhereDirect(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ed1acc7193953d980cb415bd5aacbda1</Hash>
</Codenesium>*/