using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOFamily : AbstractBusinessObject
        {
                public AbstractBOFamily()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string notes,
                                                  string pcEmail,
                                                  string pcFirstName,
                                                  string pcLastName,
                                                  string pcPhone,
                                                  int studioId)
                {
                        this.Id = id;
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;
                }

                public int Id { get; private set; }

                public string Notes { get; private set; }

                public string PcEmail { get; private set; }

                public string PcFirstName { get; private set; }

                public string PcLastName { get; private set; }

                public string PcPhone { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e04c12d3b858b3183184fdb55493bc17</Hash>
</Codenesium>*/