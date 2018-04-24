using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("Bucket", Schema="dbo")]
	public partial class EFBucket: AbstractEntityFrameworkPOCO
	{
		public EFBucket()
		{}

		public void SetProperties(
			int id,
			string name,
			Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.ExternalId = externalId.ToGuid();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="nvarchar(255)")]
		public string Name { get; set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }
	}
}

/*<Codenesium>
    <Hash>07218ceaf9b07a8263aa98df98437e92</Hash>
</Codenesium>*/