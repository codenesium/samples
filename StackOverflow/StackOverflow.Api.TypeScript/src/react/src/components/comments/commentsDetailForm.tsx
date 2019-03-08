import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentsMapper from './commentsMapper';
import CommentsViewModel from './commentsViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface CommentsDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CommentsDetailComponentState {
  model?: CommentsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CommentsDetailComponent extends React.Component<
CommentsDetailComponentProps,
CommentsDetailComponentState
> {
  state = {
    model: new CommentsViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Comments + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Comments +
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
          let response = resp.data as Api.CommentsClientResponseModel;

          console.log(response);

          let mapper = new CommentsMapper();

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
							<h3>Creation Date</h3>
							<p>{String(this.state.model!.creationDate)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>Post</h3>
							<p>{String(this.state.model!.postIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>Score</h3>
							<p>{String(this.state.model!.score)}</p>
						 </div>
					   						 <div>
							<h3>Text</h3>
							<p>{String(this.state.model!.text)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>User</h3>
							<p>{String(this.state.model!.userIdNavigation!.toDisplay())}</p>
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

export const WrappedCommentsDetailComponent = Form.create({ name: 'Comments Detail' })(
  CommentsDetailComponent
);

/*<Codenesium>
    <Hash>590a3c7ffc37ef4731df1db9c5b261bb</Hash>
</Codenesium>*/