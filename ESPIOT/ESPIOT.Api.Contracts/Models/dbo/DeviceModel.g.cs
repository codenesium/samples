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
    <Hash>32929f6885bddb64ab213b5639896684</Hash>
</Codenesium>*/