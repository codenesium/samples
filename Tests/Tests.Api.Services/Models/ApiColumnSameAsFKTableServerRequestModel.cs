using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiColumnSameAsFKTableServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiColumnSameAsFKTableServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int person,
			int personId)
		{
			this.Person = person;
			this.PersonId = personId;
		}

		[Required]
		[JsonProperty]
		public int Person { get; private set; }

		[Required]
		[JsonProperty]
		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>75aea100ef7f32fb2123470bc4476750</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/