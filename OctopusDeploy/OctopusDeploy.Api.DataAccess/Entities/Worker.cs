using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Worker", Schema="dbo")]
        public partial class Worker:AbstractEntity
        {
                public Worker()
                {
                }

                public void SetProperties(
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

                [Column("CommunicationStyle", TypeName="nvarchar(50)")]
                public string CommunicationStyle { get; private set; }

                [Column("Fingerprint", TypeName="nvarchar(50)")]
                public string Fingerprint { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDisabled", TypeName="bit")]
                public bool IsDisabled { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("MachinePolicyId", TypeName="nvarchar(50)")]
                public string MachinePolicyId { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("Thumbprint", TypeName="nvarchar(50)")]
                public string Thumbprint { get; private set; }

                [Column("WorkerPoolIds", TypeName="nvarchar(-1)")]
                public string WorkerPoolIds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>899513c7b4efaa13448ce8ee96533414</Hash>
</Codenesium>*/