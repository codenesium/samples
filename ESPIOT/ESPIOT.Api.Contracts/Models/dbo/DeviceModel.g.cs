using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class DeviceModel
	{
		public DeviceModel()
		{}

		public DeviceModel(
			string name,
			Guid publicId)
		{
			this.Name = name.ToString();
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
    <Hash>4ead78a1527137d21365115d430110b5</Hash>
</Codenesium>*/