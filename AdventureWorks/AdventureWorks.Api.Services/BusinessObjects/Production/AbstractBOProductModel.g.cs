using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductModel : AbstractBusinessObject
	{
		public AbstractBOProductModel()
			: base()
		{
		}

		public virtual void SetProperties(int productModelID,
		                                  string catalogDescription,
		                                  string instruction,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instruction = instruction;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductModelID = productModelID;
			this.Rowguid = rowguid;
		}

		public string CatalogDescription { get; private set; }

		public string Instruction { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public int ProductModelID { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7a9d602016d3f5b84e598f9266e4e9f4</Hash>
</Codenesium>*/