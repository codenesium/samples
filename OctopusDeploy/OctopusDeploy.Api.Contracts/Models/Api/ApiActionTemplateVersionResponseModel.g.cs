using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateVersionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string actionType,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.Id = id;
                        this.ActionType = actionType;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
                        this.Name = name;
                        this.Version = version;
                }

                public string ActionType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string LatestActionTemplateId { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d551e1eb7d39da4d34090e2b67930dfe</Hash>
</Codenesium>*/