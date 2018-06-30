using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerRequestModel : AbstractApiRequestModel
        {
                public ApiWorkerRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string communicationStyle,
                        string fingerprint,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string thumbprint,
                        string workerPoolIds)
                {
                        this.CommunicationStyle = communicationStyle;
                        this.Fingerprint = fingerprint;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Thumbprint = thumbprint;
                        this.WorkerPoolIds = workerPoolIds;
                }

                private string communicationStyle;

                [Required]
                public string CommunicationStyle
                {
                        get
                        {
                                return this.communicationStyle;
                        }

                        set
                        {
                                this.communicationStyle = value;
                        }
                }

                private string fingerprint;

                public string Fingerprint
                {
                        get
                        {
                                return this.fingerprint;
                        }

                        set
                        {
                                this.fingerprint = value;
                        }
                }

                private bool isDisabled;

                [Required]
                public bool IsDisabled
                {
                        get
                        {
                                return this.isDisabled;
                        }

                        set
                        {
                                this.isDisabled = value;
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

                private string machinePolicyId;

                [Required]
                public string MachinePolicyId
                {
                        get
                        {
                                return this.machinePolicyId;
                        }

                        set
                        {
                                this.machinePolicyId = value;
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

                private string relatedDocumentIds;

                public string RelatedDocumentIds
                {
                        get
                        {
                                return this.relatedDocumentIds;
                        }

                        set
                        {
                                this.relatedDocumentIds = value;
                        }
                }

                private string thumbprint;

                public string Thumbprint
                {
                        get
                        {
                                return this.thumbprint;
                        }

                        set
                        {
                                this.thumbprint = value;
                        }
                }

                private string workerPoolIds;

                public string WorkerPoolIds
                {
                        get
                        {
                                return this.workerPoolIds;
                        }

                        set
                        {
                                this.workerPoolIds = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>413239002db46bf40072208afb0158fe</Hash>
</Codenesium>*/