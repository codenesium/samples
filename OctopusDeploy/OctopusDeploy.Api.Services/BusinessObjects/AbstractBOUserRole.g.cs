using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOUserRole : AbstractBusinessObject
        {
                public AbstractBOUserRole()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  string jSON,
                                                  string name)
                {
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>63cee78836044066d058743e1408ead1</Hash>
</Codenesium>*/