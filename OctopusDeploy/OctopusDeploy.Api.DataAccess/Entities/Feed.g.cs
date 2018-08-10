using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Feed", Schema="dbo")]
	public partial class Feed : AbstractEntity
	{
		public Feed()
		{
		}

		public virtual void SetProperties(
			string feedType,
			string feedUri,
			string id,
			string jSON,
			string name)
		{
			this.FeedType = feedType;
			this.FeedUri = feedUri;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[Column("FeedType")]
		public string FeedType { get; private set; }

		[Column("FeedUri")]
		public string FeedUri { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c12e2da745003e027cbae40f1a600b65</Hash>
</Codenesium>*/