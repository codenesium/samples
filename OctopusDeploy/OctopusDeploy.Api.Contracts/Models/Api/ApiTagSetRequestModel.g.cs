using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTagSetRequestModel : AbstractApiRequestModel
        {
                public ApiTagSetRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        byte[] dataVersion,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.DataVersion = dataVersion;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                private byte[] dataVersion;

                [Required]
                public byte[] DataVersion
                {
                        get
                        {
                                return this.dataVersion;
                        }

                        set
                        {
                                this.dataVersion = value;
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
    <Hash>4ddd55f58eef599a065e51ec455369dc</Hash>
</Codenesium>*/