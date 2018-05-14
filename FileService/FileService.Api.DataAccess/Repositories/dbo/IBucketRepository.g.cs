using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		POCOBucket Create(BucketModel model);

		void Update(int id,
		            BucketModel model);

		void Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBucket Name(string name);

		POCOBucket ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>7f0436d3089afe7b39231a9aa4ce97e3</Hash>
</Codenesium>*/