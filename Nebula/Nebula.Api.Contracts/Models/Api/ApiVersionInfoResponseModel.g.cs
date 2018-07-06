using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiVersionInfoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        long version,
                        DateTime? appliedOn,
                        string description)
                {
                        this.Version = version;
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                }

                public DateTime? AppliedOn { get; private set; }

                public string Description { get; private set; }

                public long Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6929f1764bce615e9c6f2c2a9a9fe8f2</Hash>
</Codenesium>*/