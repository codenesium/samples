using Codenesium.DataConversionExtensions;
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
    <Hash>1f13c433569c51a9f5ca7ebf3e9b9ea8</Hash>
</Codenesium>*/