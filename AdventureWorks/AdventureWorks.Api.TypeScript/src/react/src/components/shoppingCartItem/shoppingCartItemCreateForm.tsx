import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ShoppingCartItemMapper from './shoppingCartItemMapper';
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';

interface Props {
    model?:ShoppingCartItemViewModel
}

   const ShoppingCartItemCreateDisplay: React.SFC<FormikProps<ShoppingCartItemViewModel>> = (props: FormikProps<ShoppingCartItemViewModel>) => {

   let status = props.status as CreateResponse<Api.ShoppingCartItemClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof ShoppingCartItemViewModel]  && props.errors[name as keyof ShoppingCartItemViewModel]) {
            response += props.errors[name as keyof ShoppingCartItemViewModel];
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
                        <label htmlFor="name" className={errorExistForField("dateCreated") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateCreated</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="dateCreated" className={errorExistForField("dateCreated") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateCreated") && <small className="text-danger">{errorsForField("dateCreated")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("productID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productID" className={errorExistForField("productID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productID") && <small className="text-danger">{errorsForField("productID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("quantity") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Quantity</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="quantity" className={errorExistForField("quantity") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("quantity") && <small className="text-danger">{errorsForField("quantity")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shoppingCartID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShoppingCartID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shoppingCartID" className={errorExistForField("shoppingCartID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shoppingCartID") && <small className="text-danger">{errorsForField("shoppingCartID")}</small>}
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


const ShoppingCartItemCreate = withFormik<Props, ShoppingCartItemViewModel>({
    mapPropsToValues: props => {
                
		let response = new ShoppingCartItemViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.dateCreated,props.model!.modifiedDate,props.model!.productID,props.model!.quantity,props.model!.shoppingCartID,props.model!.shoppingCartItemID);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ShoppingCartItemViewModel> = { };

	  if(values.dateCreated == undefined) {
                errors.dateCreated = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.productID == 0) {
                errors.productID = "Required"
                    }if(values.quantity == 0) {
                errors.quantity = "Required"
                    }if(values.shoppingCartID == '') {
                errors.shoppingCartID = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ShoppingCartItemMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.ShoppingCartItems,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ShoppingCartItemClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ShoppingCartItemCreate', 
  })(ShoppingCartItemCreateDisplay);

  interface ShoppingCartItemCreateComponentProps
  {
  }

  interface ShoppingCartItemCreateComponentState
  {
      model?:ShoppingCartItemViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ShoppingCartItemCreateComponent extends React.Component<ShoppingCartItemCreateComponentProps, ShoppingCartItemCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ShoppingCartItemCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>9de3ad51dcb9cb5dae2d5e9ee2ae2f91</Hash>
</Codenesium>*/