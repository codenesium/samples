using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceModel
	{
		public ApiDeviceModel()
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
    <Hash>6ddee2c35919e1ffc76fcf4de79c3fa6</Hash>
</Codenesium>*/