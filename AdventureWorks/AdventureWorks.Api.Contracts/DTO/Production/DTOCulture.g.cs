using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCulture: AbstractDTO
	{
		public DTOCulture() : base()
		{}

		public void SetProperties(string cultureID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>adf8a71728908b572574ae0e3b7007ea</Hash>
</Codenesium>*/