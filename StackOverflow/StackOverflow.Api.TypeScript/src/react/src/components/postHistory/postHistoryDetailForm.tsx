import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface PostHistoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistoryDetailComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostHistoryDetailComponent extends React.Component<
PostHistoryDetailComponentProps,
PostHistoryDetailComponentState
> {
  state = {
    model: new PostHistoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.PostHistories + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostHistories +
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
          let response = resp.data as Api.PostHistoryClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryMapper();

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
							<h3>Comment</h3>
							<p>{String(this.state.model!.comment)}</p>
						 </div>
					   						 <div>
							<h3>CreationDate</h3>
							<p>{String(this.state.model!.creationDate)}</p>
						 </div>
					   						 <div>
							<h3>PostHistoryTypeId</h3>
							<p>{String(this.state.model!.postHistoryTypeId)}</p>
						 </div>
					   						 <div>
							<h3>PostId</h3>
							<p>{String(this.state.model!.postId)}</p>
						 </div>
					   						 <div>
							<h3>RevisionGUID</h3>
							<p>{String(this.state.model!.revisionGUID)}</p>
						 </div>
					   						 <div>
							<h3>Text</h3>
							<p>{String(this.state.model!.text)}</p>
						 </div>
					   						 <div>
							<h3>UserDisplayName</h3>
							<p>{String(this.state.model!.userDisplayName)}</p>
						 </div>
					   						 <div>
							<h3>UserId</h3>
							<p>{String(this.state.model!.userId)}</p>
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

export const WrappedPostHistoryDetailComponent = Form.create({ name: 'PostHistory Detail' })(
  PostHistoryDetailComponent
);

/*<Codenesium>
    <Hash>aed0e3ffa74d8aa71bd1cec0a2dcee0b</Hash>
</Codenesium>*/