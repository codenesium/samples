using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IActionTemplateRepository
        {
                Task<ActionTemplate> Create(ActionTemplate item);

                Task Update(ActionTemplate item);

                Task Delete(string id);

                Task<ActionTemplate> Get(string id);

                Task<List<ActionTemplate>> All(int limit = int.MaxValue, int offset = 0);

                Task<ActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>3cca508259998062e9f885b7661e0dea</Hash>
</Codenesium>*/