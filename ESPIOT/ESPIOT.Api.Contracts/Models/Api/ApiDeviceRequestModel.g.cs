using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceRequestModel: AbstractApiRequestModel
	{
		public ApiDeviceRequestModel() : base()
		{}

		public void SetProperties(
			string name,
			Guid publicId)
		{
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private Guid publicId;

		[Required]
		public Guid PublicId
		{
			get
			{
				return this.publicId;
			}

			set
			{
				this.publicId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5ce4caefe4c3359022c24e23450080d5</Hash>
</Codenesium>*/