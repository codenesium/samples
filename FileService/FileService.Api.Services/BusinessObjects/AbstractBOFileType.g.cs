using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractBOFileType: AbstractBusinessObject
        {
                public AbstractBOFileType() : base()
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
    <Hash>6142eba57dfcc889880ac90d4778361e</Hash>
</Codenesium>*/