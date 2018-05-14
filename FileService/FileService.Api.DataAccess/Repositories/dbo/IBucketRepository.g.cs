using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		POCOBucket Create(ApiBucketModel model);

		void Update(int id,
		            ApiBucketModel model);

		void Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBucket Name(string name);

		POCOBucket ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>291e24acdf14a7572590ba49949b3d9b</Hash>
</Codenesium>*/