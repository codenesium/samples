using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Services
{
	public partial class BODevice: AbstractBusinessObject
	{
		public BODevice() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>39ba5e8d48002e053a889300af4c1c40</Hash>
</Codenesium>*/