using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityContactRequestModel : AbstractApiRequestModel
	{
		public ApiBusinessEntityContactRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.ContactTypeID = contactTypeID;
			this.ModifiedDate = modifiedDate;
			this.PersonID = personID;
			this.Rowguid = rowguid;
		}

		[Required]
		[JsonProperty]
		public int ContactTypeID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int PersonID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>56f278b5a006f1e809e46d469bd94cec</Hash>
</Codenesium>*/