using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostHistoryTypeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPostHistoryTypeServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string rwType)
		{
			this.RwType = rwType;
		}

		[Required]
		[JsonProperty]
		public string RwType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>31258698210a0a224e17597463d64a1e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/