using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentRelatedMachine", Schema="dbo")]
        public partial class DeploymentRelatedMachine : AbstractEntity
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

                [Column("DeploymentId")]
                public string DeploymentId { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("MachineId")]
                public string MachineId { get; private set; }

                [ForeignKey("DeploymentId")]
                public virtual Deployment Deployment { get; set; }
        }
}

/*<Codenesium>
    <Hash>6eb60d7f58f02a4a36ca4779b605357d</Hash>
</Codenesium>*/