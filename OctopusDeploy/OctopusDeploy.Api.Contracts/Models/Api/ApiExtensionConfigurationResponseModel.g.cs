using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiExtensionConfigurationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string extensionAuthor,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.ExtensionAuthor = extensionAuthor;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string ExtensionAuthor { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>efa35554db06c0791a6f9cbef7c4fb18</Hash>
</Codenesium>*/