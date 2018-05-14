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
    <Hash>0cb6b012ad19f7d124db52663efb3b13</Hash>
</Codenesium>*/