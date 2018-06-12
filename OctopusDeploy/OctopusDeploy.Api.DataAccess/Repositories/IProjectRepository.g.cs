using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProjectRepository
        {
                Task<Project> Create(Project item);

                Task Update(Project item);

                Task Delete(string id);

                Task<Project> Get(string id);

                Task<List<Project>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Project> GetName(string name);
                Task<Project> GetSlug(string slug);
                Task<List<Project>> GetDataVersion(byte[] dataVersion);
                Task<List<Project>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
        }
}

/*<Codenesium>
    <Hash>672128c86718f01f0e4fe438d5682918</Hash>
</Codenesium>*/