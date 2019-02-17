import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ShoppingCartItemViewModel from './shoppingCartItemViewModel';
import ShoppingCartItemMapper from './shoppingCartItemMapper';

interface Props {
    model?:ShoppingCartItemViewModel
}

  const ShoppingCartItemEditDisplay = (props: FormikProps<ShoppingCartItemViewModel>) => {

   let status = props.status as UpdateResponse<Api.ShoppingCartItemClientRequestModel>;
   
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
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
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shoppingCartItemID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShoppingCartItemID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shoppingCartItemID" className={errorExistForField("shoppingCartItemID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shoppingCartItemID") && <small className="text-danger">{errorsForField("shoppingCartItemID")}</small>}
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


const ShoppingCartItemEdit = withFormik<Props, ShoppingCartItemViewModel>({
    mapPropsToValues: props => {
        let response = new ShoppingCartItemViewModel();
		response.setProperties(props.model!.dateCreated,props.model!.modifiedDate,props.model!.productID,props.model!.quantity,props.model!.shoppingCartID,props.model!.shoppingCartItemID);	
		return response;
      },
  
    // Custom sync validation
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
                    }if(values.shoppingCartItemID == 0) {
                errors.shoppingCartItemID = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ShoppingCartItemMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.ShoppingCartItems +'/' + values.shoppingCartItemID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ShoppingCartItemClientRequestModel>;
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
  
    displayName: 'ShoppingCartItemEdit', 
  })(ShoppingCartItemEditDisplay);

 
  interface IParams 
  {
     shoppingCartItemID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ShoppingCartItemEditComponentProps
  {
     match:IMatch;
  }

  interface ShoppingCartItemEditComponentState
  {
      model?:ShoppingCartItemViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ShoppingCartItemEditComponent extends React.Component<ShoppingCartItemEditComponentProps, ShoppingCartItemEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ShoppingCartItems + '/' + this.props.match.params.shoppingCartItemID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ShoppingCartItemClientResponseModel;
            
            console.log(response);

			let mapper = new ShoppingCartItemMapper();

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
            return (<ShoppingCartItemEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>e738352cc8dfaad553b70f279f002bf5</Hash>
</Codenesium>*/