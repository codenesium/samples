using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string description,
                        string jwtKey,
                        string lastIpAddress,
                        Guid machineGuid,
                        string name)
                {
                        this.Id = id;
                        this.Description = description;
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
    <Hash>8028501d96788f7fcbdcaba532417a94</Hash>
</Codenesium>*/