using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public partial class ApiDeviceRequestModel : AbstractApiRequestModel
        {
                public ApiDeviceRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        Guid publicId)
                {
                        this.Name = name;
                        this.PublicId = publicId;
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

                private Guid publicId;

                [Required]
                public Guid PublicId
                {
                        get
                        {
                                return this.publicId;
                        }

                        set
                        {
                                this.publicId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>df4182a6561531c793b89b0edfbfacb4</Hash>
</Codenesium>*/