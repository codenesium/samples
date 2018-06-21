using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiVariableSetRequestModel : AbstractApiRequestModel
        {
                public ApiVariableSetRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        bool isFrozen,
                        string jSON,
                        string ownerId,
                        string relatedDocumentIds,
                        int version)
                {
                        this.IsFrozen = isFrozen;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Version = version;
                }

                private bool isFrozen;

                [Required]
                public bool IsFrozen
                {
                        get
                        {
                                return this.isFrozen;
                        }

                        set
                        {
                                this.isFrozen = value;
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

                private string ownerId;

                [Required]
                public string OwnerId
                {
                        get
                        {
                                return this.ownerId;
                        }

                        set
                        {
                                this.ownerId = value;
                        }
                }

                private string relatedDocumentIds;

                public string RelatedDocumentIds
                {
                        get
                        {
                                return this.relatedDocumentIds.IsEmptyOrZeroOrNull() ? null : this.relatedDocumentIds;
                        }

                        set
                        {
                                this.relatedDocumentIds = value;
                        }
                }

                private int version;

                [Required]
                public int Version
                {
                        get
                        {
                                return this.version;
                        }

                        set
                        {
                                this.version = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>537e5c1f9198462dad2eecf578437776</Hash>
</Codenesium>*/