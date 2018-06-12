using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentRelatedMachine", Schema="dbo")]
        public partial class DeploymentRelatedMachine: AbstractEntity
        {
                public DeploymentRelatedMachine()
                {
                }

                public void SetProperties(
                        string deploymentId,
                        int id,
                        string machineId)
                {
                        this.DeploymentId = deploymentId;
                        this.Id = id;
                        this.MachineId = machineId;
                }

                [Column("DeploymentId", TypeName="nvarchar(50)")]
                public string DeploymentId { get; private set; }

                [Key]
                [Column("Id", TypeName="int")]
                public int Id { get; private set; }

                [Column("MachineId", TypeName="nvarchar(50)")]
                public string MachineId { get; private set; }

                [ForeignKey("DeploymentId")]
                public virtual Deployment Deployment { get; set; }
        }
}

/*<Codenesium>
    <Hash>d3d43510b0bae8b038624b4c0bdc5ecb</Hash>
</Codenesium>*/