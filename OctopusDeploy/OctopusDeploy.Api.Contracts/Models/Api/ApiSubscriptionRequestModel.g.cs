using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiSubscriptionRequestModel : AbstractApiRequestModel
        {
                public ApiSubscriptionRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        bool isDisabled,
                        string jSON,
                        string name,
                        string type)
                {
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Type = type;
                }

                private bool isDisabled;

                [Required]
                public bool IsDisabled
                {
                        get
                        {
                                return this.isDisabled;
                        }

                        set
                        {
                                this.isDisabled = value;
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

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string type;

                public string Type
                {
                        get
                        {
                                return this.type.IsEmptyOrZeroOrNull() ? null : this.type;
                        }

                        set
                        {
                                this.type = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0a930ddf29ee8e53b40ad152ad340987</Hash>
</Codenesium>*/