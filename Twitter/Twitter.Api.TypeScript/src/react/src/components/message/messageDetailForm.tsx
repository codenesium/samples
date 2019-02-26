import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MessageMapper from './messageMapper';
import MessageViewModel from './messageViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {MessengerTableComponent} from '../shared/messengerTable'
	



interface MessageDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MessageDetailComponentState {
  model?: MessageViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MessageDetailComponent extends React.Component<
MessageDetailComponentProps,
MessageDetailComponentState
> {
  state = {
    model: new MessageViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Messages + '/edit/' + this.state.model!.messageId);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Messages +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.MessageClientResponseModel;

          console.log(response);

          let mapper = new MessageMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>content</h3>
							<p>{String(this.state.model!.content)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>sender_user_id</h3>
							<p>{String(this.state.model!.senderUserIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Messengers</h3>
            <MessengerTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Messages + '/' + this.state.model!.messageId + '/' + ApiRoutes.Messengers}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedMessageDetailComponent = Form.create({ name: 'Message Detail' })(
  MessageDetailComponent
);

/*<Codenesium>
    <Hash>58406f6710046bb7c9e22dc52773e153</Hash>
</Codenesium>*/