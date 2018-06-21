using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOLinkLog : AbstractBusinessObject
        {
                public AbstractBOLinkLog()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>d3a3a6cf614e2fe0509ca4912f5f7225</Hash>
</Codenesium>*/