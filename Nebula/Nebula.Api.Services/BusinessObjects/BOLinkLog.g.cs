using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOLinkLog: AbstractBusinessObject
        {
                public BOLinkLog() : base()
                {
                }

                public void SetProperties(int id,
                                          DateTime dateEntered,
                                          int linkId,
                                          string log)
                {
                        this.DateEntered = dateEntered;
                        this.Id = id;
                        this.LinkId = linkId;
                        this.Log = log;
                }

                public DateTime DateEntered { get; private set; }

                public int Id { get; private set; }

                public int LinkId { get; private set; }

                public string Log { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a8cb9404c1071809e4fbcab4e7b96100</Hash>
</Codenesium>*/