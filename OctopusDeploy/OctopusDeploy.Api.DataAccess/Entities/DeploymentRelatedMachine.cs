using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentRelatedMachine", Schema="dbo")]
        public partial class DeploymentRelatedMachine : AbstractEntity
        {
                public DeploymentRelatedMachine()
                {
                }

                public virtual void SetProperties(
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
    <Hash>af9206ac88b505513481997540de2a89</Hash>
</Codenesium>*/