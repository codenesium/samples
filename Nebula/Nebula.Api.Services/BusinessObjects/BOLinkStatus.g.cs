using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOLinkStatus: AbstractBusinessObject
        {
                public BOLinkStatus() : base()
                {
                }

                public void SetProperties(int id,
                                          string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>dac4a190c2800f1d497011583dbaecbd</Hash>
</Codenesium>*/