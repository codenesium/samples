import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ProductPhotoViewModel from './productPhotoViewModel';
import ProductPhotoMapper from './productPhotoMapper';

interface Props {
    model?:ProductPhotoViewModel
}

  const ProductPhotoEditDisplay = (props: FormikProps<ProductPhotoViewModel>) => {

   let status = props.status as UpdateResponse<Api.ProductPhotoClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ProductPhotoViewModel]  && props.errors[name as keyof ProductPhotoViewModel]) {
            response += props.errors[name as keyof ProductPhotoViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("largePhoto") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LargePhoto</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="largePhoto" className={errorExistForField("largePhoto") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("largePhoto") && <small className="text-danger">{errorsForField("largePhoto")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("largePhotoFileName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LargePhotoFileName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="largePhotoFileName" className={errorExistForField("largePhotoFileName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("largePhotoFileName") && <small className="text-danger">{errorsForField("largePhotoFileName")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productPhotoID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductPhotoID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productPhotoID" className={errorExistForField("productPhotoID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productPhotoID") && <small className="text-danger">{errorsForField("productPhotoID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("thumbNailPhoto") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ThumbNailPhoto</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="thumbNailPhoto" className={errorExistForField("thumbNailPhoto") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("thumbNailPhoto") && <small className="text-danger">{errorsForField("thumbNailPhoto")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("thumbnailPhotoFileName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ThumbnailPhotoFileName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="thumbnailPhotoFileName" className={errorExistForField("thumbnailPhotoFileName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("thumbnailPhotoFileName") && <small className="text-danger">{errorsForField("thumbnailPhotoFileName")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const ProductPhotoEdit = withFormik<Props, ProductPhotoViewModel>({
    mapPropsToValues: props => {
        let response = new ProductPhotoViewModel();
		response.setProperties(props.model!.largePhoto,props.model!.largePhotoFileName,props.model!.modifiedDate,props.model!.productPhotoID,props.model!.thumbNailPhoto,props.model!.thumbnailPhotoFileName);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ProductPhotoViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.productPhotoID == 0) {
                errors.productPhotoID = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ProductPhotoMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.ProductPhotoes +'/' + values.productPhotoID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ProductPhotoClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'ProductPhotoEdit', 
  })(ProductPhotoEditDisplay);

 
  interface IParams 
  {
     productPhotoID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ProductPhotoEditComponentProps
  {
     match:IMatch;
  }

  interface ProductPhotoEditComponentState
  {
      model?:ProductPhotoViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ProductPhotoEditComponent extends React.Component<ProductPhotoEditComponentProps, ProductPhotoEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ProductPhotoes + '/' + this.props.match.params.productPhotoID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ProductPhotoClientResponseModel;
            
            console.log(response);

			let mapper = new ProductPhotoMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ProductPhotoEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d62489549d3c3b8684ab1743c62dae26</Hash>
</Codenesium>*/