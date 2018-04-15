using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class FamilyModel
	{
		public FamilyModel()
		{}

		public FamilyModel(
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			string pcEmail,
			string notes,
			int studioId)
		{
			this.PcFirstName = pcFirstName.ToString();
			this.PcLastName = pcLastName.ToString();
			this.PcPhone = pcPhone.ToString();
			this.PcEmail = pcEmail.ToString();
			this.Notes = notes.ToString();
			this.StudioId = studioId.ToInt();
		}

		private string pcFirstName;

		[Required]
		public string PcFirstName
		{
			get
			{
				return this.pcFirstName;
			}

			set
			{
				this.pcFirstName = value;
			}
		}

		private string pcLastName;

		[Required]
		public string PcLastName
		{
			get
			{
				return this.pcLastName;
			}

			set
			{
				this.pcLastName = value;
			}
		}

		private string pcPhone;

		[Required]
		public string PcPhone
		{
			get
			{
				return this.pcPhone;
			}

			set
			{
				this.pcPhone = value;
			}
		}

		private string pcEmail;

		[Required]
		public string PcEmail
		{
			get
			{
				return this.pcEmail;
			}

			set
			{
				this.pcEmail = value;
			}
		}

		private string notes;

		[Required]
		public string Notes
		{
			get
			{
				return this.notes;
			}

			set
			{
				this.notes = value;
			}
		}

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>71735e0c3fa43b532676e6bc3e43bd9d</Hash>
</Codenesium>*/