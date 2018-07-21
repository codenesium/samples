using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiTeacherResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime birthday,
                        string email,
                        string firstName,
                        string lastName,
                        string phone,
                        int studioId)
                {
                        this.Id = id;
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                [Required]
                [JsonProperty]
                public DateTime Birthday { get; private set; }

                [Required]
                [JsonProperty]
                public string Email { get; private set; }

                [Required]
                [JsonProperty]
                public string FirstName { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string LastName { get; private set; }

                [Required]
                [JsonProperty]
                public string Phone { get; private set; }

                [Required]
                [JsonProperty]
                public int StudioId { get; private set; }

                [JsonProperty]
                public string StudioIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>8df94c6251c82fdb08019be4c3d72f0b</Hash>
</Codenesium>*/