import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ProductCategoryMapper from './productCategoryMapper';
import ProductCategoryViewModel from './productCategoryViewModel';

interface Props {
    model?:ProductCategoryViewModel
}

   const ProductCategoryCreateDisplay: React.SFC<FormikProps<ProductCategoryViewModel>> = (props: FormikProps<ProductCategoryViewModel>) => {

   let status = props.status as CreateResponse<Api.ProductCategoryClientRequestModel>;
   
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

   return (<form onSubmit={props.handleSubmit} role="form">            
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
          </form>);
}


const ProductCategoryCreate = withFormik<Props, ProductCategoryViewModel>({
    mapPropsToValues: props => {
                
		let response = new ProductCategoryViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.modifiedDate,props.model!.name,props.model!.productCategoryID,props.model!.rowguid);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ProductCategoryViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ProductCategoryMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.ProductCategories,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ProductCategoryClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ProductCategoryCreate', 
  })(ProductCategoryCreateDisplay);

  interface ProductCategoryCreateComponentProps
  {
  }

  interface ProductCategoryCreateComponentState
  {
      model?:ProductCategoryViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ProductCategoryCreateComponent extends React.Component<ProductCategoryCreateComponentProps, ProductCategoryCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ProductCategoryCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>3cc120f234f988841be34580daa92db6</Hash>
</Codenesium>*/