import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ProductCategoryViewModel from './productCategoryViewModel';
import ProductCategoryMapper from './productCategoryMapper';

interface Props {
    model?:ProductCategoryViewModel
}

  const ProductCategoryEditDisplay = (props: FormikProps<ProductCategoryViewModel>) => {

   let status = props.status as UpdateResponse<Api.ProductCategoryClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ProductCategoryViewModel]  && props.errors[name as keyof ProductCategoryViewModel]) {
            response += props.errors[name as keyof ProductCategoryViewModel];
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
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productCategoryID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductCategoryID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productCategoryID" className={errorExistForField("productCategoryID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productCategoryID") && <small className="text-danger">{errorsForField("productCategoryID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
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


const ProductCategoryEdit = withFormik<Props, ProductCategoryViewModel>({
    mapPropsToValues: props => {
        let response = new ProductCategoryViewModel();
		response.setProperties(props.model!.modifiedDate,props.model!.name,props.model!.productCategoryID,props.model!.rowguid);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ProductCategoryViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.productCategoryID == 0) {
                errors.productCategoryID = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ProductCategoryMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.ProductCategories +'/' + values.productCategoryID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ProductCategoryClientRequestModel>;
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
  
    displayName: 'ProductCategoryEdit', 
  })(ProductCategoryEditDisplay);

 
  interface IParams 
  {
     productCategoryID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ProductCategoryEditComponentProps
  {
     match:IMatch;
  }

  interface ProductCategoryEditComponentState
  {
      model?:ProductCategoryViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ProductCategoryEditComponent extends React.Component<ProductCategoryEditComponentProps, ProductCategoryEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ProductCategories + '/' + this.props.match.params.productCategoryID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ProductCategoryClientResponseModel;
            
            console.log(response);

			let mapper = new ProductCategoryMapper();

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
            return (<ProductCategoryEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d4cbf45e3c604c363b382b40f04aa89c</Hash>
</Codenesium>*/