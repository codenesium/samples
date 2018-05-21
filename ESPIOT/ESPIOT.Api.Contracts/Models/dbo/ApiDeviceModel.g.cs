using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceModel: AbstractModel
	{
		public ApiDeviceModel() : base()
		{}

		public ApiDeviceModel(
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
    <Hash>ef3a90c2e1f73e538ddb148b74262f99</Hash>
</Codenesium>*/