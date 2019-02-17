import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TicketMapper from './ticketMapper';
import TicketViewModel from './ticketViewModel';

interface Props {
    model?:TicketViewModel
}

   const TicketCreateDisplay: React.SFC<FormikProps<TicketViewModel>> = (props: FormikProps<TicketViewModel>) => {

   let status = props.status as CreateResponse<Api.TicketClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof TicketViewModel]  && props.errors[name as keyof TicketViewModel]) {
            response += props.errors[name as keyof TicketViewModel];
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
                        <label htmlFor="name" className={errorExistForField("publicId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PublicId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="publicId" className={errorExistForField("publicId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("publicId") && <small className="text-danger">{errorsForField("publicId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("ticketStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TicketStatusId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="ticketStatusId" className={errorExistForField("ticketStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("ticketStatusId") && <small className="text-danger">{errorsForField("ticketStatusId")}</small>}
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


const TicketCreate = withFormik<Props, TicketViewModel>({
    mapPropsToValues: props => {
                
		let response = new TicketViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.publicId,props.model!.ticketStatusId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<TicketViewModel> = { };

	  if(values.publicId == '') {
                errors.publicId = "Required"
                    }if(values.ticketStatusId == 0) {
                errors.ticketStatusId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new TicketMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Tickets,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.TicketClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'TicketCreate', 
  })(TicketCreateDisplay);

  interface TicketCreateComponentProps
  {
  }

  interface TicketCreateComponentState
  {
      model?:TicketViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TicketCreateComponent extends React.Component<TicketCreateComponentProps, TicketCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<TicketCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>1cc9bc592517ab0fd907bd852822056f</Hash>
</Codenesium>*/