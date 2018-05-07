using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IBucketRepository
	{
		int Create(BucketModel model);

		void Update(int id,
		            BucketModel model);

		void Delete(int id);

		POCOBucket Get(int id);

		List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2827892a529441edcea8c221a905c0cb</Hash>
</Codenesium>*/