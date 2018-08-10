using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("KeyAllocation", Schema="dbo")]
	public partial class KeyAllocation : AbstractEntity
	{
		public KeyAllocation()
		{
		}

		public virtual void SetProperties(
			int allocated,
			string collectionName)
		{
			this.Allocated = allocated;
			this.CollectionName = collectionName;
		}

		[Column("Allocated")]
		public int Allocated { get; private set; }

		[Key]
		[Column("CollectionName")]
		public string CollectionName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9bf77a09d7fbb48fc5902e333aedd080</Hash>
</Codenesium>*/