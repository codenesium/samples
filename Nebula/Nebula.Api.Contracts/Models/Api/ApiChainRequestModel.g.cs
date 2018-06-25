using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainRequestModel : AbstractApiRequestModel
        {
                public ApiChainRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>b6c4fa75429fcc10acd158763eab298f</Hash>
</Codenesium>*/