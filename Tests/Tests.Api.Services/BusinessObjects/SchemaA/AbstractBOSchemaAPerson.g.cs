using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBOSchemaAPerson : AbstractBusinessObject
        {
                public AbstractBOSchemaAPerson()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>8b140fdca1fd7b90ab88dce93a878322</Hash>
</Codenesium>*/