import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';

interface Props {
    model?:CreditCardViewModel
}

   const CreditCardCreateDisplay: React.SFC<FormikProps<CreditCardViewModel>> = (props: FormikProps<CreditCardViewModel>) => {

   let status = props.status as CreateResponse<Api.CreditCardClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof CreditCardViewModel]  && props.errors[name as keyof CreditCardViewModel]) {
            response += props.errors[name as keyof CreditCardViewModel];
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
                        <label htmlFor="name" className={errorExistForField("cardNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CardNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="cardNumber" className={errorExistForField("cardNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("cardNumber") && <small className="text-danger">{errorsForField("cardNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("cardType") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CardType</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="cardType" className={errorExistForField("cardType") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("cardType") && <small className="text-danger">{errorsForField("cardType")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("expMonth") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExpMonth</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="expMonth" className={errorExistForField("expMonth") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("expMonth") && <small className="text-danger">{errorsForField("expMonth")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("expYear") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExpYear</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="expYear" className={errorExistForField("expYear") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("expYear") && <small className="text-danger">{errorsForField("expYear")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
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


const CreditCardCreate = withFormik<Props, CreditCardViewModel>({
    mapPropsToValues: props => {
                
		let response = new CreditCardViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.cardNumber,props.model!.cardType,props.model!.creditCardID,props.model!.expMonth,props.model!.expYear,props.model!.modifiedDate);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<CreditCardViewModel> = { };

	  if(values.cardNumber == '') {
                errors.cardNumber = "Required"
                    }if(values.cardType == '') {
                errors.cardType = "Required"
                    }if(values.expMonth == 0) {
                errors.expMonth = "Required"
                    }if(values.expYear == 0) {
                errors.expYear = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new CreditCardMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.CreditCards,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.CreditCardClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'CreditCardCreate', 
  })(CreditCardCreateDisplay);

  interface CreditCardCreateComponentProps
  {
  }

  interface CreditCardCreateComponentState
  {
      model?:CreditCardViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CreditCardCreateComponent extends React.Component<CreditCardCreateComponentProps, CreditCardCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<CreditCardCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>1bdbb9e364c6ccf6873aa3bb91079da8</Hash>
</Codenesium>*/