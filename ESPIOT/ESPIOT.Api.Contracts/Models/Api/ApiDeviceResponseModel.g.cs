using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public partial class ApiDeviceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bfd0ab1992ccea2249295f20815b919b</Hash>
</Codenesium>*/