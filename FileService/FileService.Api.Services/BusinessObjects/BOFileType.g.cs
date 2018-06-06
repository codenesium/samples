using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
	public partial class BOFileType: AbstractBusinessObject
	{
		public BOFileType() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>390e4c05d612bcc62fadf51837871afc</Hash>
</Codenesium>*/