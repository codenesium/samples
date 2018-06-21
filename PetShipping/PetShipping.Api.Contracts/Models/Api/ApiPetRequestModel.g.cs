using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>0d69a4394406542207108a7fa95c2bb1</Hash>
</Codenesium>*/