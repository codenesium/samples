using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Services
{
        public partial class BODevice: AbstractBusinessObject
        {
                public BODevice() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7f02e0773d2c291f00f0160042fb1d2c</Hash>
</Codenesium>*/