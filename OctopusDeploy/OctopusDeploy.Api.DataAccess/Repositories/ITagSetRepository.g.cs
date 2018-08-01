using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface ITagSetRepository
	{
		Task<TagSet> Create(TagSet item);

		Task Update(TagSet item);

		Task Delete(string id);

		Task<TagSet> Get(string id);

		Task<List<TagSet>> All(int limit = int.MaxValue, int offset = 0);

		Task<TagSet> ByName(string name);

		Task<List<TagSet>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>9f3b08b2d82e712934095e8024c1fa7d</Hash>
</Codenesium>*/