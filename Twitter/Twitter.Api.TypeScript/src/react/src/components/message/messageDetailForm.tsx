import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import MessageMapper from './messageMapper';
import MessageViewModel from './messageViewModel';

interface Props {
	history:any;
    model?:MessageViewModel
}

const MessageDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Messages + '/edit/' + model.model!.messageId)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="content" className={"col-sm-2 col-form-label"}>Content</label>
							<div className="col-sm-12">
								{String(model.model!.content)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="senderUserId" className={"col-sm-2 col-form-label"}>Sender_user_id</label>
							<div className="col-sm-12">
								{model.model!.senderUserIdNavigation!.toDisplay()}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     messageId:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface MessageDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface MessageDetailComponentState
  {
      model?:MessageViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class MessageDetailComponent extends React.Component<MessageDetailComponentProps, MessageDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Messages + '/' + this.props.match.params.messageId,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.MessageClientResponseModel;
            
			let mapper = new MessageMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
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
            return (<MessageDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>ed95617dff3774150d8cca4e0df0fa8e</Hash>
</Codenesium>*/