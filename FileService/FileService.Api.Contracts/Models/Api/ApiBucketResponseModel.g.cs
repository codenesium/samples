using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiBucketResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        Guid externalId,
                        string name)
                {
                        this.Id = id;
                        this.ExternalId = externalId;
                        this.Name = name;
                }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4508d1e79af0d69937588cc97eac898d</Hash>
</Codenesium>*/