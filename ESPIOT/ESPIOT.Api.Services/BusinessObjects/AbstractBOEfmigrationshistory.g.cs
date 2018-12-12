using Codenesium.DataConversionExtensions;
using System;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractBOEfmigrationshistory : AbstractBusinessObject
	{
		public AbstractBOEfmigrationshistory()
			: base()
		{
		}

		public virtual void SetProperties(string migrationId,
		                                  string productVersion)
		{
			this.MigrationId = migrationId;
			this.ProductVersion = productVersion;
		}

		public string MigrationId { get; private set; }

		public string ProductVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>327e321f9db50100db0b55dd1abccbed</Hash>
</Codenesium>*/