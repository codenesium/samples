using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Worker", Schema="dbo")]
        public partial class Worker : AbstractEntity
        {
                public Worker()
                {
                }

                public virtual void SetProperties(
                        string communicationStyle,
                        string fingerprint,
                        string id,
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
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Thumbprint = thumbprint;
                        this.WorkerPoolIds = workerPoolIds;
                }

                [Column("CommunicationStyle")]
                public string CommunicationStyle { get; private set; }

                [Column("Fingerprint")]
                public string Fingerprint { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsDisabled")]
                public bool IsDisabled { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("MachinePolicyId")]
                public string MachinePolicyId { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("RelatedDocumentIds")]
                public string RelatedDocumentIds { get; private set; }

                [Column("Thumbprint")]
                public string Thumbprint { get; private set; }

                [Column("WorkerPoolIds")]
                public string WorkerPoolIds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9a5866f44a5ca8226bbff6a018bcc028</Hash>
</Codenesium>*/