using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkLogResponseModel: AbstractApiResponseModel
	{
		public ApiLinkLogResponseModel() : base()
		{}

		public void SetProperties(
			DateTime dateEntered,
			int id,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.Log = log;

			this.LinkId = new ReferenceEntity<int>(linkId,
			                                       nameof(ApiResponse.Links));
		}

		public DateTime DateEntered { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> LinkId { get; set; }
		public string Log { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDateEnteredValue { get; set; } = true;

		public bool ShouldSerializeDateEntered()
		{
			return this.ShouldSerializeDateEnteredValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkIdValue { get; set; } = true;

		public bool ShouldSerializeLinkId()
		{
			return this.ShouldSerializeLinkIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLogValue { get; set; } = true;

		public bool ShouldSerializeLog()
		{
			return this.ShouldSerializeLogValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDateEnteredValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLinkIdValue = false;
			this.ShouldSerializeLogValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5cec00fa7e75265b6aa3d2108b2723ad</Hash>
</Codenesium>*/