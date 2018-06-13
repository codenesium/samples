using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IChannelRepository
        {
                Task<Channel> Create(Channel item);

                Task Update(Channel item);

                Task Delete(string id);

                Task<Channel> Get(string id);

                Task<List<Channel>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Channel> GetNameProjectId(string name, string projectId);
                Task<List<Channel>> GetDataVersion(byte[] dataVersion);
                Task<List<Channel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>405af1b639a8ba3ca3332ac6bab8a4d3</Hash>
</Codenesium>*/