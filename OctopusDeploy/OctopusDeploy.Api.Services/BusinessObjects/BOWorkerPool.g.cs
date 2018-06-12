using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOWorkerPool: AbstractBusinessObject
        {
                public BOWorkerPool() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>26081de5e018807b3dc8de1aea951404</Hash>
</Codenesium>*/