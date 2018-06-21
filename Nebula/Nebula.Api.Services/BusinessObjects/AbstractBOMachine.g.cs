using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOMachine : AbstractBusinessObject
        {
                public AbstractBOMachine()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>fae05cc83e9b8538caf1705dc6dac0f2</Hash>
</Codenesium>*/