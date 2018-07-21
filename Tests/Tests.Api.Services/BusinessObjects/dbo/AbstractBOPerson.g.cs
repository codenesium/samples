using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBOPerson : AbstractBusinessObject
        {
                public AbstractBOPerson()
                        : base()
                {
                }

                public virtual void SetProperties(int personId,
                                                  string personName)
                {
                        this.PersonId = personId;
                        this.PersonName = personName;
                }

                public int PersonId { get; private set; }

                public string PersonName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5925b897bb66580788763ef5c4a8acfd</Hash>
</Codenesium>*/