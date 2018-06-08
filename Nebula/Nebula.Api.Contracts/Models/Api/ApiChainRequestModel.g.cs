using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainRequestModel: AbstractApiRequestModel
        {
                public ApiChainRequestModel() : base()
                {
                }

                public void SetProperties(
                        int chainStatusId,
                        Guid externalId,
                        string name,
                        int teamId)
                {
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Name = name;
                        this.TeamId = teamId;
                }

                private int chainStatusId;

                [Required]
                public int ChainStatusId
                {
                        get
                        {
                                return this.chainStatusId;
                        }

                        set
                        {
                                this.chainStatusId = value;
                        }
                }

                private Guid externalId;

                [Required]
                public Guid ExternalId
                {
                        get
                        {
                                return this.externalId;
                        }

                        set
                        {
                                this.externalId = value;
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

                private int teamId;

                [Required]
                public int TeamId
                {
                        get
                        {
                                return this.teamId;
                        }

                        set
                        {
                                this.teamId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>524af79dd74b43fdb4245b3c5dadc326</Hash>
</Codenesium>*/