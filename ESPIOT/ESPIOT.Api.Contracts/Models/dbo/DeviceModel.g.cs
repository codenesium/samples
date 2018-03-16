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

		public DeviceModel(string name,
		                   Guid publicId)
		{
			this.Name = name;
			this.PublicId = publicId;
		}

		public DeviceModel(POCODevice poco)
		{
			this.Name = poco.Name;
			this.PublicId = poco.PublicId;
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
	}
}

/*<Codenesium>
    <Hash>afb56485d355f4699ee97f281090c1c2</Hash>
</Codenesium>*/