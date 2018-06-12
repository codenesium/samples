using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerPoolRequestModel: AbstractApiRequestModel
        {
                public ApiWorkerPoolRequestModel() : base()
                {
                }

                public void SetProperties(
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
    <Hash>4da8b6e7cc4e0f5fabe237d6b03fe8f1</Hash>
</Codenesium>*/