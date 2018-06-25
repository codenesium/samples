using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineRequestModel : AbstractApiRequestModel
        {
                public ApiMachineRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string description,
                        string jwtKey,
                        string lastIpAddress,
                        Guid machineGuid,
                        string name)
                {
                        this.Description = description;
                        this.JwtKey = jwtKey;
                        this.LastIpAddress = lastIpAddress;
                        this.MachineGuid = machineGuid;
                        this.Name = name;
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private string jwtKey;

                [Required]
                public string JwtKey
                {
                        get
                        {
                                return this.jwtKey;
                        }

                        set
                        {
                                this.jwtKey = value;
                        }
                }

                private string lastIpAddress;

                [Required]
                public string LastIpAddress
                {
                        get
                        {
                                return this.lastIpAddress;
                        }

                        set
                        {
                                this.lastIpAddress = value;
                        }
                }

                private Guid machineGuid;

                [Required]
                public Guid MachineGuid
                {
                        get
                        {
                                return this.machineGuid;
                        }

                        set
                        {
                                this.machineGuid = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>05454323e62a039f53a4e5402bb7b3d7</Hash>
</Codenesium>*/