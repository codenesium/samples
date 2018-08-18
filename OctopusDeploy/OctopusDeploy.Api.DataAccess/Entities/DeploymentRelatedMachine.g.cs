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

		[MaxLength(50)]
		[Column("DeploymentId")]
		public string DeploymentId { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("MachineId")]
		public string MachineId { get; private set; }

		[ForeignKey("DeploymentId")]
		public virtual Deployment DeploymentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>18c7bfa6896f509dfb9a9dc4728bb8ad</Hash>
</Codenesium>*/