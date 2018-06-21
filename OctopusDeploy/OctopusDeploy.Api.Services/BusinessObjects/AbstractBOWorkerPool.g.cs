using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOWorkerPool : AbstractBusinessObject
        {
                public AbstractBOWorkerPool()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  bool isDefault,
                                                  string jSON,
                                                  string name,
                                                  int sortOrder)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                public string Id { get; private set; }

                public bool IsDefault { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e089d6847ae9fc48c2186132bd96bb93</Hash>
</Codenesium>*/