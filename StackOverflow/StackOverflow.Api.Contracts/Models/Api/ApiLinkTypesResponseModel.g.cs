using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiLinkTypesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string type)
                {
                        this.Id = id;
                        this.Type = type;
                }

                public int Id { get; private set; }

                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>dac6024c3ac1cc087403dee687908f37</Hash>
</Codenesium>*/