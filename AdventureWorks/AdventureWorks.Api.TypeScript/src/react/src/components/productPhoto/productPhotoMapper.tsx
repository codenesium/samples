import * as Api from '../../api/models';
import ProductPhotoViewModel from  './productPhotoViewModel';
export default class ProductPhotoMapper {
    
	mapApiResponseToViewModel(dto: Api.ProductPhotoClientResponseModel) : ProductPhotoViewModel 
	{
		let response = new ProductPhotoViewModel();
		response.setProperties(dto.largePhoto,dto.largePhotoFileName,dto.modifiedDate,dto.productPhotoID,dto.thumbNailPhoto,dto.thumbnailPhotoFileName);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ProductPhotoViewModel) : Api.ProductPhotoClientRequestModel
	{
		let response = new Api.ProductPhotoClientRequestModel();
		response.setProperties(model.largePhoto,model.largePhotoFileName,model.modifiedDate,model.productPhotoID,model.thumbNailPhoto,model.thumbnailPhotoFileName);
		return response;
	}
};

/*<Codenesium>
    <Hash>d14e0428d7633ca775398592cb382a68</Hash>
</Codenesium>*/