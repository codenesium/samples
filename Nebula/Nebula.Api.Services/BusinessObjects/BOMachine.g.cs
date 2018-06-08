using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOMachine: AbstractBusinessObject
        {
                public BOMachine() : base()
                {
                }

                public void SetProperties(int id,
                                          string description,
                                          string jwtKey,
                                          string lastIpAddress,
                                          Guid machineGuid,
                                          string name)
                {
                        this.Description = description;
                        this.Id = id;
                        this.JwtKey = jwtKey;
                        this.LastIpAddress = lastIpAddress;
                        this.MachineGuid = machineGuid;
                        this.Name = name;
                }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public string JwtKey { get; private set; }

                public string LastIpAddress { get; private set; }

                public Guid MachineGuid { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6f97aa58f58f953b62a2eb03c4c7412f</Hash>
</Codenesium>*/