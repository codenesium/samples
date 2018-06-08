using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOTeam:AbstractBusinessObject
        {
                public BOTeam() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          int organizationId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.OrganizationId = organizationId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int OrganizationId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b7cd57c25d9b3e69b63fcef490805b01</Hash>
</Codenesium>*/