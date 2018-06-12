using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("WorkerTaskLease", Schema="dbo")]
        public partial class WorkerTaskLease: AbstractEntity
        {
                public WorkerTaskLease()
                {
                }

                public void SetProperties(
                        bool exclusive,
                        string id,
                        string jSON,
                        string name,
                        string taskId,
                        string workerId)
                {
                        this.Exclusive = exclusive;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TaskId = taskId;
                        this.WorkerId = workerId;
                }

                [Column("Exclusive", TypeName="bit")]
                public bool Exclusive { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("TaskId", TypeName="nvarchar(50)")]
                public string TaskId { get; private set; }

                [Column("WorkerId", TypeName="nvarchar(50)")]
                public string WorkerId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7a0fe65ee4b361ed9282220144919dd1</Hash>
</Codenesium>*/