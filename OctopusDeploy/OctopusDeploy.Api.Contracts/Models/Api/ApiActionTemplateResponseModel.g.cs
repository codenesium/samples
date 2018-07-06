using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string actionType,
                        string communityActionTemplateId,
                        string jSON,
                        string name,
                        int version)
                {
                        this.Id = id;
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                public string ActionType { get; private set; }

                public string CommunityActionTemplateId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cea2472978e8efe81a8548e486bc4e18</Hash>
</Codenesium>*/