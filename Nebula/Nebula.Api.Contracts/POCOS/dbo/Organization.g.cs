using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOOrganization
	{
		public POCOOrganization()
		{}

		public POCOOrganization(int id,
		                        string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id {get; set;}
		public string Name {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d9ed47ce39e7e333dddaea8d1bc09bc9</Hash>
</Codenesium>*/