import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ReplyMapper from './replyMapper';
import ReplyViewModel from './replyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface ReplyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ReplyDetailComponentState {
  model?: ReplyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ReplyDetailComponent extends React.Component<
ReplyDetailComponentProps,
ReplyDetailComponentState
> {
  state = {
    model: new ReplyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Replies + '/edit/' + this.state.model!.replyId);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Replies +
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
          let response = resp.data as Api.ReplyClientResponseModel;

          console.log(response);

          let mapper = new ReplyMapper();

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
					   						 <div>
							<h3>date</h3>
							<p>{String(this.state.model!.date)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>replier_user_id</h3>
							<p>{String(this.state.model!.replierUserIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>time</h3>
							<p>{String(this.state.model!.time)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedReplyDetailComponent = Form.create({ name: 'Reply Detail' })(
  ReplyDetailComponent
);

/*<Codenesium>
    <Hash>e9ceab9cb91f38dc4e4285bdcfcbcdaa</Hash>
</Codenesium>*/