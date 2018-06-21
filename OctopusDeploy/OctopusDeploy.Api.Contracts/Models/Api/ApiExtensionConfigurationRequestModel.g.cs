using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiExtensionConfigurationRequestModel : AbstractApiRequestModel
        {
                public ApiExtensionConfigurationRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string extensionAuthor,
                        string jSON,
                        string name)
                {
                        this.ExtensionAuthor = extensionAuthor;
                        this.JSON = jSON;
                        this.Name = name;
                }

                private string extensionAuthor;

                public string ExtensionAuthor
                {
                        get
                        {
                                return this.extensionAuthor.IsEmptyOrZeroOrNull() ? null : this.extensionAuthor;
                        }

                        set
                        {
                                this.extensionAuthor = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string name;

                public string Name
                {
                        get
                        {
                                return this.name.IsEmptyOrZeroOrNull() ? null : this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>1f0f8da6df46bdfb1582b2c870c3d95b</Hash>
</Codenesium>*/