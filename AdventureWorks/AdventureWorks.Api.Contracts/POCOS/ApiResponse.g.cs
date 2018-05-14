using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AdventureWorksNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "V")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "O")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

		public void Merge(ApiResponse from)
		{}

		public void DisableSerializationOfEmptyFields()
		{               }
	}
}

/*<Codenesium>
    <Hash>e6f5573f673ee777c675b75a35b22049</Hash>
</Codenesium>*/