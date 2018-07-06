using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiLibraryVariableSetResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string contentType,
                        string jSON,
                        string name,
                        string variableSetId)
                {
                        this.Id = id;
                        this.ContentType = contentType;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                public string ContentType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7d07ea357bfa1767a9956ede0c10df6b</Hash>
</Codenesium>*/