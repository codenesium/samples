using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOStudio : AbstractBusinessObject
	{
		public AbstractBOStudio()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string address1,
		                                  string address2,
		                                  string city,
		                                  string name,
		                                  string province,
		                                  string website,
		                                  string zip,
		                                  bool isDeleted)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id;
			this.Name = name;
			this.Province = province;
			this.Website = website;
			this.Zip = zip;
			this.IsDeleted = isDeleted;
		}

		public string Address1 { get; private set; }

		public string Address2 { get; private set; }

		public string City { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Province { get; private set; }

		public string Website { get; private set; }

		public string Zip { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c1a43bb51e2a5c17b0991fd6c2681c5f</Hash>
</Codenesium>*/