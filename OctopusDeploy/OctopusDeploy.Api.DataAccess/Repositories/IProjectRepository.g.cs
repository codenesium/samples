using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProjectRepository
        {
                Task<Project> Create(Project item);

                Task Update(Project item);

                Task Delete(string id);

                Task<Project> Get(string id);

                Task<List<Project>> All(int limit = int.MaxValue, int offset = 0);

                Task<Project> GetName(string name);

                Task<Project> GetSlug(string slug);

                Task<List<Project>> GetDataVersion(byte[] dataVersion);

                Task<List<Project>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
        }
}

/*<Codenesium>
    <Hash>0a8a6dc32d88404e8b8088fab56c4361</Hash>
</Codenesium>*/