using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace NebulaNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		public T Value { get; set; }
		public string Href
		{
			get
			{
				return $"/{this.ReferenceObjectName}/{this.Value.ToString()}";
			}
		}
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class Response
	{
		public Response()
		{}

		public void DisableSerializationOfEmptyFields()
		{               }
	}
}

/*<Codenesium>
    <Hash>d504076d6ef55c45aa33a2431d81bf16</Hash>
</Codenesium>*/