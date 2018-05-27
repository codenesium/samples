using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductProductPhoto: AbstractBOProductProductPhoto, IBOProductProductPhoto
	{
		public BOProductProductPhoto(
			ILogger<ProductProductPhotoRepository> logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper productProductPhotoMapper)
			: base(logger, productProductPhotoRepository, productProductPhotoModelValidator, productProductPhotoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>efb834ef6e179b823bd81c680dd473bf</Hash>
</Codenesium>*/