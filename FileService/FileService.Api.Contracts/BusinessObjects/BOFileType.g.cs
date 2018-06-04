using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
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
    <Hash>b3a297ac663158a230c48be5c6032cf3</Hash>
</Codenesium>*/