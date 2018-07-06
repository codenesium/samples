using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiTeamResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int organizationId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.OrganizationId = organizationId;

                        this.OrganizationIdEntity = nameof(ApiResponse.Organizations);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int OrganizationId { get; private set; }

                public string OrganizationIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>3b358ce932b078b2b8aa1e4caac25610</Hash>
</Codenesium>*/