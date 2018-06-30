using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerPoolRequestModel : AbstractApiRequestModel
        {
                public ApiWorkerPoolRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool isDefault,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                private bool isDefault;

                [Required]
                public bool IsDefault
                {
                        get
                        {
                                return this.isDefault;
                        }

                        set
                        {
                                this.isDefault = value;
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

                private int sortOrder;

                [Required]
                public int SortOrder
                {
                        get
                        {
                                return this.sortOrder;
                        }

                        set
                        {
                                this.sortOrder = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f40fe180b51c6105c40a686799100742</Hash>
</Codenesium>*/