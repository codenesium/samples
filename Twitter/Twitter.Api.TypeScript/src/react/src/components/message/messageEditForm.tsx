import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import MessageViewModel from './messageViewModel';
import MessageMapper from './messageMapper';

interface Props {
    model?:MessageViewModel
}

  const MessageEditDisplay = (props: FormikProps<MessageViewModel>) => {

   let status = props.status as UpdateResponse<Api.MessageClientRequestModel>;
   
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
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
          </form>
  );
}


const MessageEdit = withFormik<Props, MessageViewModel>({
    mapPropsToValues: props => {
        let response = new MessageViewModel();
		response.setProperties(props.model!.content,props.model!.messageId,props.model!.senderUserId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<MessageViewModel> = { };

	  if(values.messageId == 0) {
                errors.messageId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new MessageMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Messages +'/' + values.messageId,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.MessageClientRequestModel>;
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
  
    displayName: 'MessageEdit', 
  })(MessageEditDisplay);

 
  interface IParams 
  {
     messageId:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface MessageEditComponentProps
  {
     match:IMatch;
  }

  interface MessageEditComponentState
  {
      model?:MessageViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class MessageEditComponent extends React.Component<MessageEditComponentProps, MessageEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Messages + '/' + this.props.match.params.messageId, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.MessageClientResponseModel;
            
            console.log(response);

			let mapper = new MessageMapper();

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
            return (<MessageEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>99e5e5351374e99ee5a20efe4e2e5532</Hash>
</Codenesium>*/