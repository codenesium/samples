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

		public DeviceModel(Guid publicId,
		                   string name)
		{
			this.PublicId = publicId;
			this.Name = name;
		}

		public DeviceModel(POCODevice poco)
		{
			this.PublicId = poco.PublicId;
			this.Name = poco.Name;
		}

		private Guid _publicId;
		[Required]
		public Guid PublicId
		{
			get
			{
				return _publicId;
			}
			set
			{
				this._publicId = value;
			}
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d76728c38b5954b87a966f2defcd5263</Hash>
</Codenesium>*/