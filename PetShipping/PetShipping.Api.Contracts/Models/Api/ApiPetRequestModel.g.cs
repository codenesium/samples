using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPetRequestModel : AbstractApiRequestModel
        {
                public ApiPetRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int breedId,
                        int clientId,
                        string name,
                        int weight)
                {
                        this.BreedId = breedId;
                        this.ClientId = clientId;
                        this.Name = name;
                        this.Weight = weight;
                }

                private int breedId;

                [Required]
                public int BreedId
                {
                        get
                        {
                                return this.breedId;
                        }

                        set
                        {
                                this.breedId = value;
                        }
                }

                private int clientId;

                [Required]
                public int ClientId
                {
                        get
                        {
                                return this.clientId;
                        }

                        set
                        {
                                this.clientId = value;
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

                private int weight;

                [Required]
                public int Weight
                {
                        get
                        {
                                return this.weight;
                        }

                        set
                        {
                                this.weight = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a153526b6517f6995aef7dbd0c20d8a6</Hash>
</Codenesium>*/