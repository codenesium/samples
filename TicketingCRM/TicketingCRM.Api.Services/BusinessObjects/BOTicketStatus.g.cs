using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOTicketStatus: AbstractBusinessObject
        {
                public BOTicketStatus() : base()
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
    <Hash>87930ee154355fbcce136b930f088f8b</Hash>
</Codenesium>*/