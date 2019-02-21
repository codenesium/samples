import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import MessageMapper from './messageMapper';
import MessageViewModel from './messageViewModel';

interface Props {
    model?:MessageViewModel
}

   const MessageCreateDisplay: React.SFC<FormikProps<MessageViewModel>> = (props: FormikProps<MessageViewModel>) => {

   let status = props.status as CreateResponse<Api.MessageClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof MessageViewModel]  && props.errors[name as keyof MessageViewModel]) {
            response += props.errors[name as keyof MessageViewModel];
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
                        <label htmlFor="name" className={errorExistForField("content") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Content</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="content" className={errorExistForField("content") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("content") && <small className="text-danger">{errorsForField("content")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("senderUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Sender_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="senderUserId" className={errorExistForField("senderUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("senderUserId") && <small className="text-danger">{errorsForField("senderUserId")}</small>}
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


const MessageCreate = withFormik<Props, MessageViewModel>({
    mapPropsToValues: props => {
                
		let response = new MessageViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.content,props.model!.messageId,props.model!.senderUserId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<MessageViewModel> = { };

	  

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new MessageMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Messages,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.MessageClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'MessageCreate', 
  })(MessageCreateDisplay);

  interface MessageCreateComponentProps
  {
  }

  interface MessageCreateComponentState
  {
      model?:MessageViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class MessageCreateComponent extends React.Component<MessageCreateComponentProps, MessageCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<MessageCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>22a223709f0454dfdc4389ba75b8dcee</Hash>
</Codenesium>*/