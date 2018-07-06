using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTeamResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string environmentIds,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.Id = id;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string MemberUserIds { get; private set; }

                public string Name { get; private set; }

                public string ProjectGroupIds { get; private set; }

                public string ProjectIds { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b6ee685ed2e4cd05d907cfc3b2970b54</Hash>
</Codenesium>*/