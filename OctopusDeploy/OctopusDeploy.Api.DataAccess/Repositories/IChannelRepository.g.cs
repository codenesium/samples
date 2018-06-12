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

                Task<List<Channel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Channel> GetNameProjectId(string name, string projectId);
                Task<List<Channel>> GetDataVersion(byte[] dataVersion);
                Task<List<Channel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>cc18004f7ed99c413684dfdffed49e55</Hash>
</Codenesium>*/